using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using agis.Integrations.Payment.AuthorizeNET.net.authorize.api;

namespace agis.Integrations.Payment.AuthorizeNET
{
    public enum TransactionType
    {
        AuthorizeOnly,
        AuthorizeAndCapture
    }

    public class Gateway
    {
        private Service _arbService;
        private bool _useTestUrl;

        public string API_Login { get; set; }
        public string TransactionKey { get; set; }
        public bool UseTestUrl {
            get { return _useTestUrl; }
            set
            {
                _useTestUrl = value;
                _arbService = null;
            }
        }
        public TransactionType TransactionType { get; set; }

        public Gateway()
        {
            UseTestUrl = true;
            TransactionType = AuthorizeNET.TransactionType.AuthorizeOnly;
        }

        private string GetAPIUrl(bool ForSubscription)
        {
            if (ForSubscription)
            {
                if (UseTestUrl)
                    return "https://apitest.authorize.net/soap/v1/Service.asmx";
                else
                    return "https://api.authorize.net/soap/v1/Service.asmx";
            }
            else
            {
                if (UseTestUrl)
                    return "https://test.authorize.net/gateway/transact.dll";
                else
                    return "https://secure.authorize.net/gateway/transact.dll";
            }
        }

        private string GetTransactionType()
        {
            if (TransactionType == AuthorizeNET.TransactionType.AuthorizeAndCapture)
                return "AUTH_CAPTURE";
            else
                return "AUTH_ONLY";
        }

        public TransactionResult ProcessSingleTransaction(CreditCardInfo CCInfo, CustomerInfo CustInfo, OrderInfo OrderInfo)
        {
            TransactionResult result = new TransactionResult();
            string postUrl = GetAPIUrl(false);

            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("x_login", API_Login);
            values.Add("x_tran_key", TransactionKey);
            values.Add("x_delim_data", "TRUE");
            values.Add("x_delim_char", "|");
            values.Add("x_relay_response", "FALSE");

            
            values.Add("x_type", GetTransactionType());
            values.Add("x_method", "CC");
            values.Add("x_card_num", CCInfo.CardNumber);
            values.Add("x_exp_date", CCInfo.ExpirationMonth.ToString("0#") + CCInfo.ExpirationYear.ToString().Substring(2));
            if (!string.IsNullOrEmpty(CCInfo.CardCode)) values.Add("x_card_code", CCInfo.CardCode);

            values.Add("x_test_request", OrderInfo.TestTransaction.ToString().ToUpper());
            values.Add("x_invoice_num", OrderInfo.InvoiceNumber);
            values.Add("x_amount", OrderInfo.Amount.ToString("#.00"));
            values.Add("x_description", OrderInfo.OrderSummary);

            values.Add("x_first_name", CustInfo.FirstName);
            values.Add("x_last_name", CustInfo.LastName);
            values.Add("x_email", CustInfo.Email);
            values.Add("x_address", CustInfo.Address);
            values.Add("x_city", CustInfo.City);
            values.Add("x_state", CustInfo.State);
            values.Add("x_zip", CustInfo.Zip);

            String postString = "";

            foreach (KeyValuePair<string, string> value in values)
            {
                postString += value.Key + "=" + HttpUtility.UrlEncode(value.Value) + "&";
            }
            postString = postString.TrimEnd('&');

            // create an HttpWebRequest object to communicate with Authorize.net
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(postUrl);
            objRequest.Method = "POST";
            objRequest.ContentLength = postString.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                // post data is sent as a stream
                StreamWriter myWriter = null;
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(postString);
                myWriter.Close();

                // returned values are returned as a stream, then read into a string
                String post_response;
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
                {
                    post_response = responseStream.ReadToEnd();
                    responseStream.Close();
                }

                string[] responses = post_response.Split('|');

                result.ResponseCode = responses[0];
                result.ResponseReasonCode = responses[2];
                result.Message = responses[3];
                result.RawResponse = post_response;

                switch (result.ResponseCode)
                {
                    case "1":
                        result.Response = Response.Approved;
                        result.Approved = true;
                        break;
                    case "2":
                        result.Response = Response.Declined;
                        break;
                    case "3":
                        result.Response = Response.Error;
                        break;
                    case "4":
                        result.Response = Response.HeldForReview;
                        break;
                }
            }
            catch (Exception ex)
            {
                result.Response = Response.Error;
                result.Message = ex.Message;
            }

            return result;
        }

        #region --- Subscriptions ---

        private ARBSubscriptionUnitEnum GetSubscriptionUnit(IntervalUnit Unit)
        {
            if (Unit == IntervalUnit.Days)
                return ARBSubscriptionUnitEnum.days;
            if (Unit == IntervalUnit.Months)
                return ARBSubscriptionUnitEnum.months;

            throw new Exception("Interval unit of " + Unit.ToString() + " not supported by Authorize.NET");
        }

        public SubscriptionResult CreateSubscription(CreditCardInfo CCInfo, CustomerInfo CustInfo, SubscriptionInfo SubInfo, OrderInfo OrderInfo)
        {
            SubscriptionResult result = new SubscriptionResult();

            Console.WriteLine("\r\nCreate subscription");

            MerchantAuthenticationType authentication = GetMerchantAuthentication();

            ARBSubscriptionType subscription = new ARBSubscriptionType();

            PopulateSubscription(subscription, CCInfo, CustInfo, SubInfo, OrderInfo, false);

            ARBCreateSubscriptionResponseType response;
            response = GetArbService().ARBCreateSubscription(authentication, subscription);

            if (response.resultCode == MessageTypeEnum.Ok)
            {
                result.Successful = true;
                result.SubscriptionId = response.subscriptionId;
                result.Message = string.Format("A subscription with an ID of '{0}' was successfully created.", response.subscriptionId);
            }
            else
            {
                result.Successful = false;
                result.Message = GetSubscriptionErrors(response);
            }

            return result;
        }

        private static void PopulateSubscription(ARBSubscriptionType sub, CreditCardInfo CCInfo, CustomerInfo CustInfo, SubscriptionInfo SubInfo, OrderInfo OrderInfo, bool bForUpdate)
        {
            CreditCardType creditCard = new CreditCardType();

            sub.name = SubInfo.SubscriptionName;

            creditCard.cardNumber = CCInfo.CardNumber;
            creditCard.expirationDate = CCInfo.ExpirationYear.ToString("0000") + "-" + CCInfo.ExpirationMonth.ToString("00");

            sub.payment = new PaymentType();
            sub.payment.Item = creditCard;

            sub.billTo = new NameAndAddressType();
            sub.billTo.firstName = CustInfo.FirstName;
            sub.billTo.lastName = CustInfo.LastName;
            sub.billTo.address = CustInfo.Address;
            sub.billTo.city = CustInfo.City;
            sub.billTo.state = CustInfo.State;
            sub.billTo.zip = CustInfo.Zip;

            sub.paymentSchedule = new PaymentScheduleType();
            sub.paymentSchedule.startDate = SubInfo.StartDate;
            sub.paymentSchedule.startDateSpecified = true;

            sub.paymentSchedule.totalOccurrences = SubInfo.TotalOccurrences;
            sub.paymentSchedule.totalOccurrencesSpecified = true;

            sub.amount = (decimal)OrderInfo.Amount;
            sub.amountSpecified = true;

            if (!bForUpdate)
            { // Interval can't be updated once a subscription is created.
                sub.paymentSchedule.interval = new PaymentScheduleTypeInterval();
                sub.paymentSchedule.interval.length = SubInfo.Interval;
                sub.paymentSchedule.interval.unit = ARBSubscriptionUnitEnum.months;
            }
        }

        private Service GetArbService()
        {
            if (_arbService == null)
            {
                _arbService = new Service();
                _arbService.Url = GetAPIUrl(true);

            }

            return _arbService;
        }

        private MerchantAuthenticationType GetMerchantAuthentication()
        {
            MerchantAuthenticationType authentication = new MerchantAuthenticationType();
            authentication.name = API_Login;
            authentication.transactionKey = TransactionKey;
            return authentication;
        }

        private string GetSubscriptionErrors(ANetApiResponseType response)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The API request failed with the following errors:");

            for (int i = 0; i < response.messages.Length; i++)
            {
                sb.AppendFormat("[{0}] {1}\r\n", response.messages[i].code, response.messages[i].text);
            }

            return sb.ToString();
        }

        #endregion --- Subscriptions ---
    }
}
