using System.Net;
using AGIS.Integrations.Newsletter.LisTrak.LisTrak;

public class Integration
{
    IntegrationService _service = null;

    private IntegrationService Service
    {
        get
        {
            if (_service == null)
            {
                _service = GetWebService();
            }

            return _service;
        }
    }
   
    public string UserName { get; set; }
    public string Password { get; set; }

    public SubscribeContactResult Subscribe(int ListId, string EmailAddress)
    {
        SubscribeContactResult result = Service.SubscribeContact(ListId, EmailAddress, false);

        return result;
    }

    private IntegrationService GetWebService()
    {
        IntegrationService service = new IntegrationService();
        service.Credentials = new NetworkCredential(UserName, Password);
        service.PreAuthenticate = true;

        return service;
    }
}
