using GymManager.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Navigation
{
    public class MenuAppService : IMenuAppService
    {
        public List<UserMenuItem> GetMenu()
        {
            List<UserMenuItem> listMenus = new List<UserMenuItem>();


            listMenus.Add(new UserMenuItem
            {
                Name = "Home",
                DisplayName= "Home",
                Order = 0,
                Url = "/",
            });

            listMenus.Add(new UserMenuItem
            {
                Name = "Administration",
                DisplayName = "Administration",
                Order = 1,
                Url = "#",
                Items = new List<UserMenuItem>
                {
                    new UserMenuItem
                    {
                        Name= "MembershipTypes",
                        DisplayName = "Memberships Types",
                        Order = 0,
                        Url= "/MembershipTypes/",
                    },
                    
                    new UserMenuItem
                    {
                        Name= "EquipmentTypes",
                        DisplayName = "Equipment Types",
                        Order = 1,
                        Url= "/EquipmentTypes/",
                    },


                 new UserMenuItem
                    {
                        Name= "UserManagment",
                        DisplayName = "Users",
                        Order = 2,
                        Url= "/Users/",
                    }


                }

            });




            listMenus.Add(new UserMenuItem
            {
                Name = "Members",
                DisplayName = "Members",
                Order = 2,
                Url = "#",
                Items = new List<UserMenuItem>()
                {
                    new UserMenuItem
                    {
                        Name = "Managment",
                        DisplayName = "Managment",
                        Order = 0,
                        Url = "/Members/"
                    },

                    new UserMenuItem
                    {
                        Name = "MembershipRenewal",
                        DisplayName = "Membership Renewal",
                        Order = 1,
                        Url = "/MembershipRenewal"
                    },

                    new UserMenuItem
                    {
                        Name = "Attendance",
                        DisplayName = "Attendance",
                        Order = 2,
                        Url = "/Attendance"
                    }
                }
            });

            listMenus.Add(new UserMenuItem
            {
                Name = "Invoicing",
                DisplayName = "Invoicing",
                Order = 3,
                Url = "#",

                Items = new List<UserMenuItem>()
                { 
                    new UserMenuItem
                    {
                        Name = "Invoicing",
                        DisplayName = "Invoicing",
                        Order = 0,
                        Url = "/Invoicing/GenerateInvoice"
                    }
                }
            });

            listMenus.Add(new UserMenuItem
            {
                Name = "Reports",
                DisplayName = "Reports",
                Order = 4,
                Url = "#",
                Items = new List<UserMenuItem>()
                {
                    new UserMenuItem
                    {
                        Name = "NewMembersReport",
                        DisplayName = "New Members",
                        Order = 0,
                        Url = "/Reports/NewMembers"
                    },

                    new UserMenuItem
                    {
                        Name = "AttendanceReport",
                        DisplayName = "Attendance",
                        Order = 1,
                        Url = "/Reports/Attendance"
                    }

                }
            });

            return listMenus;
        }  
    }
}
