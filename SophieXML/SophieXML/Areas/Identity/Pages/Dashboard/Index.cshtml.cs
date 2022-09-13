using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SophieXML.Model;
using SophieXML.Units;

namespace SophieXML.Areas.Identity.Pages.Dashboard
{
    //[Authorize(Roles = RolePrefix.AdminSys + "," + RolePrefix.Admin + "," + RolePrefix.Developer + "," + RolePrefix.Manager)]
    //[Authorize(Roles = RolePrefix.Admin + "," + RolePrefix.Developer + "," + RolePrefix.Moderator)]
    //[Authorize(Policy = "RequireAdministratorRoleForCMS")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public XMLModel? Document { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public class SubmitModel
        {
        }

        public IActionResult OnPostProgress(SubmitModel model, IFormFile[] attachment)
        {
            //IFormFileCollection attachment = HttpContext.Request.Form.Files;
            Logs.debug($"File size: {attachment.Length}");
            if (attachment.Length > 0)
            {
                List<string> listImages = new List<string>();
                foreach (IFormFile file in attachment)
                {
                    if (file.Length == 0) continue;
                    //string uploadDirecotroy = "/uploads";
                    //string uploadPath = $"{System.IO.Directory.GetCurrentDirectory()}/wwwroot{uploadDirecotroy}";
                    //var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}".FixFileName();
                    //var path = Path.Combine(uploadPath, fileName);
                    //using (var stream = new FileStream(path, FileMode.Create))
                    //{
                    //    await file.CopyToAsync(stream);
                    //}
                    //listImages.Add($"{uploadDirecotroy}/{fileName}");

                    //var reader = new StreamReader(file.OpenReadStream());
                    //var jsonText = await reader.ReadToEndAsync();
                    //Logs.debug(jsonText);

                    //XmlReaderSettings settings = new XmlReaderSettings() { IgnoreWhitespace = true };
                    //XmlReader reader = XmlReader.Create(file.OpenReadStream(), settings);
                    //while (reader.Read())
                    //{
                    //    switch (reader.NodeType)
                    //    {
                    //        case XmlNodeType.Element:
                    //            Console.WriteLine($"Start Element: {reader.Name}. Has Attributes? : {reader.HasAttributes}");
                    //            break;
                    //        case XmlNodeType.Text:
                    //            Console.WriteLine($"Inner Text: {reader.Value}");
                    //            break;
                    //        case XmlNodeType.EndElement:
                    //            Console.WriteLine($"End Element: {reader.Name}");
                    //            break;
                    //        default:
                    //            Console.WriteLine($"Unknown: {reader.NodeType}");
                    //            break;
                    //    }
                    //}

                    XmlSerializer serializer = new XmlSerializer(typeof(XMLModel));
                    XMLModel myDocument = (XMLModel)serializer.Deserialize(file.OpenReadStream());
                    foreach (FILEHOSO item in myDocument.THONGTINHOSO.DANHSACHHOSO.HOSO)
                    {
                        string xmlData = "";
                        switch (item.LOAIHOSO)
                        {
                            case "XML1":
                                xmlData = Encoding.UTF8.GetString(Convert.FromBase64String(item.NOIDUNGFILE));
                                //Logs.debug($"XML - {item.LOAIHOSO}\n{xmlData}");
                                serializer = new XmlSerializer(typeof(XML1Model));
                                XML1Model documentXML1 = (XML1Model)serializer.Deserialize(new StringReader(xmlData));
                                //Logs.debug($"JSON - {item.LOAIHOSO}\n{Newtonsoft.Json.JsonConvert.SerializeObject(documentXML1, JsonSettings.SettingForNewtonsoftPretty)}");
                                item.NOIDUNG = documentXML1;
                                break;
                            case "XML2":
                                xmlData = Encoding.UTF8.GetString(Convert.FromBase64String(item.NOIDUNGFILE));
                                //Logs.debug($"XML - {item.LOAIHOSO}\n{xmlData}");
                                serializer = new XmlSerializer(typeof(XML2Model));
                                XML2Model documentXML2 = (XML2Model)serializer.Deserialize(new StringReader(xmlData));
                                //Logs.debug($"JSON - {item.LOAIHOSO}\n{Newtonsoft.Json.JsonConvert.SerializeObject(documentXML2, JsonSettings.SettingForNewtonsoftPretty)}");
                                item.NOIDUNG = documentXML2;
                                break;
                            case "XML3":
                                xmlData = Encoding.UTF8.GetString(Convert.FromBase64String(item.NOIDUNGFILE));
                                //Logs.debug($"XML - {item.LOAIHOSO}\n{xmlData}");
                                serializer = new XmlSerializer(typeof(XML3Model));
                                XML3Model documentXML3 = (XML3Model)serializer.Deserialize(new StringReader(xmlData));
                                //Logs.debug($"JSON - {item.LOAIHOSO}\n{Newtonsoft.Json.JsonConvert.SerializeObject(documentXML3, JsonSettings.SettingForNewtonsoftPretty)}");
                                item.NOIDUNG = documentXML3;
                                break;
                            case "XML5":
                                xmlData = Encoding.UTF8.GetString(Convert.FromBase64String(item.NOIDUNGFILE));
                                //Logs.debug($"XML - {item.LOAIHOSO}\n{xmlData}");
                                serializer = new XmlSerializer(typeof(XML5Model));
                                XML5Model documentXML5 = (XML5Model)serializer.Deserialize(new StringReader(xmlData));
                                //Logs.debug($"JSON - {item.LOAIHOSO}\n{Newtonsoft.Json.JsonConvert.SerializeObject(documentXML5, JsonSettings.SettingForNewtonsoftPretty)}");
                                item.NOIDUNG = documentXML5;
                                break;
                            default:
                                xmlData = Encoding.UTF8.GetString(Convert.FromBase64String(item.NOIDUNGFILE));
                                Logs.debug($"{item.LOAIHOSO}\n{xmlData}");
                                break;
                        }
                    }
                    Logs.debug($"[XML] Data:\n{Newtonsoft.Json.JsonConvert.SerializeObject(myDocument, JsonSettings.SettingForNewtonsoftPretty)}");
                    Document = myDocument;
                }
            }

            StatusMessage = "Progress successfully";
            //return LocalRedirect($"~/Identity/Dashboard");
            return Page();
        }

    }
}

