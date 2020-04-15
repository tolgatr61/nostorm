﻿using OpenNos.Master.Library.Client;
using OpenNos.Master.Library.Data;
using System;
using System.Configuration;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BuyController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index(ItemModel model)
        {
            try
            {
                if (MallServiceClient.Instance.Authenticate(ConfigurationManager.AppSettings["MasterAuthKey"]))
                {
                    MallServiceClient.Instance.SendItem(model.CharacterId, new MallItem()
                    {
                        ItemVNum = model.ItemVNum,
                        Amount = model.Amount,
                        Rare = model.Rare,
                        Upgrade = model.Upgrade,
                        Level = model.Design
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[INFO] {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} - Item send to the CharacterId : {model.CharacterId}");
                    return Ok($"Item succeffuly send to the character {model.CharacterId}");
                }

                return BadRequest();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}