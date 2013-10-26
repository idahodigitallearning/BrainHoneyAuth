using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDLALogin.Models.SAML2;

namespace IDLALogin.Controllers
{
    public class SAMLController : Controller
    {
        //
        // GET: /SAML/

        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /SAML/Metadata
        public ActionResult Metadata()
        {
            ResponseType response = new ResponseType();
            response.ID = "_" + Guid.NewGuid().ToString();
            response.Destination = recipient;
            response.Version = "2.0";
            response.IssueInstant = System.DateTime.UtcNow;

            NameIDType issuerForResponse = new NameIDType();
            issuerForResponse.Value = issuer.Trim();

            response.Issuer = issuerForResponse;

            StatusType status = new StatusType();
            status.StatusCode = new StatusCodeType();
            status.StatusCode.Value = "urn:oasis:names:tc:SAML:2.0:status:Success";
            response.Status = status;
        }

    }
}
