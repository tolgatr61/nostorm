/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using OpenNos.Core;
using OpenNos.Data;
using OpenNos.Domain;
using OpenNos.GameObject.Helpers;
using System;

namespace OpenNos.GameObject
{
    public class UpgradeItem : Item
    {
        #region Instantiation

        public UpgradeItem(ItemDTO item) : base(item)
        {
        }

        #endregion

        #region Methods

        public override void Use(ClientSession session, ref ItemInstance inv, byte Option = 0, string[] packetsplit = null)
        {
            if (session.Character.IsVehicled)
            {
                session.SendPacket(session.Character.GenerateSay(Language.Instance.GetMessageFromKey("CANT_DO_VEHICLED"), 10));
                return;
            }

            if (session.CurrentMapInstance.MapInstanceType == MapInstanceType.TalentArenaMapInstance)
            {
                return;
            }

            if (Effect == 0)
            {
                if (EffectValue != 0)
                {
                    if (session.Character.IsSitting)
                    {
                        session.Character.IsSitting = false;
                        session.SendPacket(session.Character.GenerateRest());
                    }
                    session.SendPacket(UserInterfaceHelper.GenerateGuri(12, 1, session.Character.CharacterId, EffectValue));
                }
                else if (EffectValue == 0)
                {
                    if (packetsplit?.Length > 9 && byte.TryParse(packetsplit[8], out byte TypeEquip) && short.TryParse(packetsplit[9], out short SlotEquip))
                    {
                        if (session.Character.IsSitting)
                        {
                            session.Character.IsSitting = false;
                            session.SendPacket(session.Character.GenerateRest());
                        }
                        if (Option != 0)
                        {
                            bool isUsed = false;
                            switch (inv.ItemVNum)
                            {
                                case 5870:
                                    {
                                        ItemInstance equip1 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        if (equip1 != null)
                                        {
                                            if (equip1.Upgrade != 10)
                                             {
                                                 // set upgrade to +10
                                                 equip1.Upgrade = 10;

                                                 //Send Changed stuff to client <not wendig>
                                                 session.SendPacket(equip1.GenerateInventoryAdd());

                                                 //remove item from Inventory
                                                 session.Character.Inventory.RemoveItemFromInventory(inv.Id);

                                                 //save character
                                                 session.Character.Save();

                                                 // Effect animation
                                                 session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));

                                             }
                                             else
                                             {
                                                 // Upgrade is already 10
                                                 session.SendPacket("info Your Equipment is already +10");
                                             }
                                              
                                           
                                        }

                                    }
                                    break;

                                case 5869:
                                    {
                                        ItemInstance equip1 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        if (equip1 != null)
                                        {
                                            if (equip1.Upgrade != 9)
                                            {
                                                // set upgrade to +10
                                                equip1.Upgrade = 9;

                                                //Send Changed stuff to client <not wendig>
                                                session.SendPacket(equip1.GenerateInventoryAdd());

                                                //remove item from Inventory
                                                session.Character.Inventory.RemoveItemFromInventory(inv.Id);

                                                //save character
                                                session.Character.Save();

                                                // Effect animation
                                                session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));

                                            }
                                            else
                                            {
                                                // Upgrade is already 10
                                                session.SendPacket("info Your Equipment is already +9");
                                            }


                                        }

                                    }
                                    break;

                                case 5858:
                                    {
                                        ItemInstance equip1 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        if (equip1 != null)
                                        {
                                            if (equip1.Upgrade != 9)
                                            {
                                                // set upgrade to +10
                                                equip1.Upgrade = 9;

                                                //Send Changed stuff to client <not wendig>
                                                session.SendPacket(equip1.GenerateInventoryAdd());

                                                //remove item from Inventory
                                                session.Character.Inventory.RemoveItemFromInventory(inv.Id);

                                                //save character
                                                session.Character.Save();

                                                // Effect animation
                                                session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));

                                            }
                                            else
                                            {
                                                // Upgrade is already 10
                                                session.SendPacket("info Your Equipment is already +9");
                                            }


                                        }

                                    }
                                    break;

                                case 7000:
                                    {
                                        ItemInstance equip1 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        if (equip1 != null)
                                        {
                                            if(equip1.Item.EquipmentSlot == EquipmentType.MainWeapon)
                                            {
                                                switch(equip1.HP)
                                                {
                                                    case 0:
                                                        equip1.HitRate += 50;
                                                        equip1.DamageMaximum += 50;
                                                        equip1.DamageMinimum += 50;
                                                        equip1.CriticalRate += 10;
                                                        equip1.CriticalLuckRate += 3;
                                                        equip1.HP = 1;
                                                        break;
                                                    case 1:
                                                          equip1.HitRate += 50;
                                                        equip1.DamageMaximum += 50;
                                                        equip1.DamageMinimum += 50;
                                                        equip1.CriticalRate += 10;
                                                        equip1.CriticalLuckRate += 3;
                                                        equip1.HP = 2;
                                                        break;
                                                    case 2:
                                                        equip1.HitRate += 50;
                                                        equip1.DamageMaximum += 50;
                                                        equip1.DamageMinimum += 50;
                                                        equip1.CriticalRate += 10;
                                                        equip1.CriticalLuckRate += 3;
                                                        equip1.HP = 3;
                                                        break;
                                                    case 3:
                                                        equip1.HitRate += 50;
                                                        equip1.DamageMaximum += 50;
                                                        equip1.DamageMinimum += 50;
                                                        equip1.CriticalRate += 10;
                                                        equip1.CriticalLuckRate += 3;
                                                        equip1.HP = 1;
                                                        break;
                                                }
                                                break;                                         
                                            }
                                        }
                                    }
                                    break;

                                case 5868:
                                    {
                                        ItemInstance equip1 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        if (equip1 != null)
                                        {
                                            if (equip1.Upgrade != 10 && equip1.Item.EquipmentSlot == EquipmentType.MainWeapon &&
                                                equip1.Upgrade != 10 && equip1.Item.EquipmentSlot == EquipmentType.Armor &&
                                                equip1.Upgrade != 10 && equip1.Item.EquipmentSlot == EquipmentType.SecondaryWeapon)
                                            {
                                                // set upgrade to +10
                                                equip1.Upgrade = 10;

                                                //Send Changed stuff to client <not wendig>
                                                session.SendPacket(equip1.GenerateInventoryAdd());

                                                //remove item from Inventory
                                                session.Character.Inventory.RemoveItemFromInventory(inv.Id);

                                                //save character
                                                session.Character.Save();

                                                // Effect animation
                                                session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));

                                            }
                                            else
                                            {
                                                // Upgrade is already 10
                                                session.SendPacket("info Your Equipment is already +10");
                                            }


                                        }

                                    }
                                    break;

                                case 5518:
                                    {
                                        ItemInstance equip2 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        if (equip2 != null)
                                        {
                                            if (!equip2.Item.Name.Contains("Ultimate"))
                                            {
                                                session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));                                               
                                                equip2.DamageMinimum += 50;
                                                equip2.DamageMaximum += 50;
                                                session.Character.Inventory.RemoveItemFromInventory(inv.Id);
                                                session.Character.Save();
                                            }
                                            else
                                            {
                                                // Upgrade is already 10
                                                session.SendPacket("info Your Equipment is not limited anymore");
                                            }
                                        }
                                    }
                                    break;

                                case 1208:
                                    {
                                        ItemInstance equip2 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        ItemInstance generatedItem;
                                        if (equip2 != null)
                                        {
                                            switch (equip2.Item.VNum)
                                            {
                                                case 8005:
                                                    generatedItem = new ItemInstance(4129, 1);
                                                    break;
                                                case 8006:
                                                    generatedItem = new ItemInstance(4130, 1);
                                                    break;
                                                case 8007:
                                                    generatedItem = new ItemInstance(4131, 1);
                                                    break;
                                                case 8008:
                                                    generatedItem = new ItemInstance(4132, 1);
                                                    break;
                                                default:
                                                    session.SendPacket("This isn't the right item");
                                                    return;
                                            }
                                                session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));
                                                session.Character.Inventory.RemoveItemFromInventory(inv.Id);
                                                session.Character.Inventory.RemoveItemFromInventory(equip2.Id);
                                                session.Character.Inventory.AddToInventory(generatedItem);
                                                session.Character.Save();                                                                                
                                        }
                                    }
                                    break;

                                    
                                case 1209:
                                    {
                                        ItemInstance equip2 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        ItemInstance generatedItem;
                                        Random random = new Random();
                                        int randomNumber = random.Next(0, 100);
                                        if (equip2 != null)
                                        {
                                            if (randomNumber <= 50)
                                            {
                                                switch (equip2.Item.VNum)
                                                {
                                                    case 4129:
                                                        generatedItem = new ItemInstance(4709, 1);
                                                        break;
                                                    case 4130:
                                                        generatedItem = new ItemInstance(4710, 1);
                                                        break;
                                                    case 4131:
                                                        generatedItem = new ItemInstance(4711, 1);
                                                        break;
                                                    case 4132:
                                                        generatedItem = new ItemInstance(4712, 1);
                                                        break;
                                                    default:
                                                        session.SendPacket("This isn't the right item");
                                                        return;
                                                }
                                            }
                                            else
                                            {
                                                switch (equip2.Item.VNum)
                                                {
                                                    case 4129:
                                                        generatedItem = new ItemInstance(4705, 1);
                                                        break;
                                                    case 4130:
                                                        generatedItem = new ItemInstance(4706, 1);
                                                        break;
                                                    case 4131:
                                                        generatedItem = new ItemInstance(4707, 1);
                                                        break;
                                                    case 4132:
                                                        generatedItem = new ItemInstance(4708, 1);
                                                        break;
                                                    default:
                                                        session.SendPacket("This isn't the right item");
                                                        return;
                                                }

                                            }

                                            session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));
                                            session.Character.Inventory.RemoveItemFromInventory(inv.Id);
                                            session.Character.Inventory.RemoveItemFromInventory(equip2.Id);
                                            session.Character.Inventory.AddToInventory(generatedItem);
                                            session.Character.Save();
                                        }
                                    }
                                    break;

                                case 1210:
                                    {
                                        ItemInstance equip2 = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                        ItemInstance generatedItem;
                                        if (equip2 != null)
                                        {
                                            switch (equip2.Item.VNum)
                                            {
                                                case 4709:
                                                    generatedItem = new ItemInstance(4713, 1);
                                                    break;
                                                case 4710:
                                                    generatedItem = new ItemInstance(4714, 1);
                                                    break;
                                                case 4711:
                                                    generatedItem = new ItemInstance(4715, 1);
                                                    break;
                                                case 4712:
                                                    generatedItem = new ItemInstance(4716, 1);
                                                    break;
                                                case 4705:
                                                    generatedItem = new ItemInstance(4713, 1);
                                                    break;
                                                case 4706:
                                                    generatedItem = new ItemInstance(4714, 1);
                                                    break;
                                                case 4707:
                                                    generatedItem = new ItemInstance(4715, 1);
                                                    break;
                                                case 4708:
                                                    generatedItem = new ItemInstance(4716, 1);
                                                    break;
                                                default:
                                                    session.SendPacket("This isn't the right item");
                                                    return;
                                            }
                                            session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));
                                            session.Character.Inventory.RemoveItemFromInventory(inv.Id);
                                            session.Character.Inventory.RemoveItemFromInventory(equip2.Id);
                                            session.Character.Inventory.AddToInventory(generatedItem);
                                            session.Character.Save();
                                        }
                                    }
                                    break;




                                case 1219:
                                case 9130:
                                    ItemInstance equip = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                    if (equip?.IsFixed == true)
                                    {
                                        equip.IsFixed = false;
                                        session.SendPacket(StaticPacketHelper.GenerateEff(UserType.Player, session.Character.CharacterId, 3003));
                                        session.SendPacket(UserInterfaceHelper.GenerateGuri(17, 1, session.Character.CharacterId, SlotEquip));
                                        session.SendPacket(session.Character.GenerateSay(Language.Instance.GetMessageFromKey("ITEM_UNFIXED"), 12));
                                        isUsed = true;
                                    }
                                    break;

                                case 1365:
                                case 9039:
                                    ItemInstance specialist = session.Character.Inventory.LoadBySlotAndType(SlotEquip, (InventoryType)TypeEquip);
                                    if (specialist?.Rare == -2)
                                    {
                                        specialist.Rare = 0;
                                        session.SendPacket(UserInterfaceHelper.GenerateMsg(Language.Instance.GetMessageFromKey("SP_RESURRECTED"), 0));
                                        session.SendPacket(UserInterfaceHelper.GenerateGuri(13, 1, session.Character.CharacterId, 1));
                                        session.Character.SpPoint = 10000;
                                        if (session.Character.SpPoint > 10000)
                                        {
                                            session.Character.SpPoint = 10000;
                                        }
                                        session.SendPacket(session.Character.GenerateSpPoint());
                                        session.SendPacket(specialist.GenerateInventoryAdd());
                                        isUsed = true;
                                    }
                                    break;
                            }
                            if (!isUsed)
                            {


                                session.SendPacket(session.Character.GenerateSay(Language.Instance.GetMessageFromKey("ITEM_IS_NOT_FIXED"), 11));

                            }
                            else
                            {
                                session.Character.Inventory.RemoveItemFromInventory(inv.Id);
                            }

                        }
                        else
                        {
                            session.SendPacket($"qna #u_i^1^{session.Character.CharacterId}^{(byte)inv.Type}^{inv.Slot}^0^1^{TypeEquip}^{SlotEquip} {Language.Instance.GetMessageFromKey("QNA_ITEM")}");
                        }
                    }
                }
            }
            else
            {
                Logger.Warn(string.Format(Language.Instance.GetMessageFromKey("NO_HANDLER_ITEM"), GetType(), VNum, Effect, EffectValue));
            }
        }

        #endregion
    }
}