using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Investment.Models;
using Business;
using Entity;

namespace Investment.Controllers
{
    public class AttachmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage(AttachmentControl ac)
        {
            AttachmentModel attachmentModel = new AttachmentModel();
            var attachmentList = attachmentModel.GetAttachment(ac.Table, ac.Id);
            if (ac.EnumAttachmentType.HasValue)
            {
                attachmentList = attachmentList.Where(a => a.EnumAttachmentType == (int)ac.EnumAttachmentType).ToList();
            }
            return PartialView(attachmentList);
        }
    }
}
