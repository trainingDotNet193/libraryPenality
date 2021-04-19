using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>  
        /// Get: /MultiSelectDropDown/Index method.  
        /// </summary>          
        /// <returns>Return index view</returns>  
        public ActionResult Index()
        {
            // Initialization.  
            InputPage inputPage = new InputPage();
            inputPage.Countries= new MultiSelectDropDownViewModel { SelectedMultiCountryId = new List<int>(), SelectedCountryLst = new List<Country>() };

            try
            {
                // Loading drop down lists.  
                this.ViewBag.CountryList = this.GetCountryList();
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.View(inputPage);
        }

 

        #region POST: /MultiSelectDropDown/Index  

        /// <summary>  
        /// POST: /MultiSelectDropDown/Index  
        /// </summary>  
        /// <param name="model">Model parameter</param>  
        /// <returns>Return - Response information</returns>  
        [HttpPost]
   
        public ActionResult Index(InputPage model)
        {
           
         
            try
            {
                // Verification  
                if (ModelState.IsValid)
                {
                    // Initialization.  
                    List<Country> countryList = this.LoadData();

                    // Selected countries list.  
                    model.Countries.SelectedCountryLst = countryList.Where(p => model.Countries.SelectedMultiCountryId.Contains(p.Country_Id)).Select(q => q).ToList();
                }

                // Loading drop down lists.  
                this.ViewBag.CountryList = this.GetCountryList();

                List<Result> results = new List<Result>();
                for (int i = 0; i < model.Countries.SelectedMultiCountryId.Count(); i++)
                {
                    Result result = new Result();
                    result.SelectedCountry = getCountryById(model.Countries.SelectedMultiCountryId[i]);


                    result.BusinessDays = calculateBusinessDays(model, result.SelectedCountry);
                    float fine = 0f;
                    if (model.CheckOut.AddDays(10) > model.Return)
                    {
                        //calculating fine
                        for (int j = 0; j < result.BusinessDays; j++)
                        {
                            fine += result.SelectedCountry.perDayFine;
                        }

                    }
                    result.Fine = fine;
                    results.Add(result);
                }

                model.Results = results;
                return View(model);

            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info  
            return this.View(model);
        }

        private Country getCountryById(int id) 
        {
            List<Country> countryList = this.LoadData();
            Country country = new Country();
            for (int i=0; i < countryList.Count(); i++ ) 
            {
                if (countryList[i].Country_Id == id)
                {
                    country = countryList[i];
                    i = countryList.Count();
                }
            }


            return country;
        }
        private int calculateBusinessDays(InputPage inputPage,Country SelectedCountry)
        {
            DateTime date = inputPage.CheckOut;
            int businessDays = 0;
            while (date != inputPage.Return)
            {

                for (int i = 0; i <  SelectedCountry.Holidays.Count(); i++)
                {
                    Holiday holiday =  SelectedCountry.Holidays[i];
                    if (date != holiday.Date)
                    {
                        businessDays++;
                    }
                }
                date.AddDays(1);
            }
            return businessDays;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult InputPage()
        {
            InputPage inputPage = new InputPage();
            //inputPage.Countries = new List<Country>();

            //Country country = new Country();
            //country.Id = 1;
            //country.Name = "Pakistan";
            //inputPage.Countries.Add(country);

            //country.Id = 2;
            //country.Name = "Turkey";
            //inputPage.Countries.Add(country);

            return View(inputPage);
        }

        /// <summary>  
        /// Load data method.  
        /// </summary>  
        /// <returns>Returns - Data</returns>  
        private List<Country> LoadData()
        {
            // Initialization.  
            List<Country> lst = new List<Country>();

            try
            {
                Country infoObj = new Country();
                

                // Setting.  
                infoObj.Country_Id = 1;
                infoObj.Country_Name = "Pakistan";
                infoObj.currency = "Pkr";
                infoObj.perDayFine = 5f;

                infoObj.Holidays = new List<Holiday>();
                
                Holiday holiday = new Holiday();
                holiday.Name = "Weekend";
                holiday.DayName = "Saturday";
                holiday.Date = DateTime.Now;

                infoObj.Holidays.Add(holiday);

                // Adding.  
                lst.Add(infoObj);

                Country infoObj2 = new Country();
                infoObj2.Country_Id = 2;
                infoObj2.Country_Name = "Turkey";
                infoObj2.currency = "Lera";
                infoObj2.perDayFine = 5f;

                infoObj.Holidays = new List<Holiday>();

                Holiday holiday2 = new Holiday();
                holiday2.Name = "Weekend";
                holiday2.DayName = "Saturday";
                holiday2.Date = DateTime.Now;

                infoObj.Holidays.Add(holiday2);
                // Adding.  
                lst.Add(infoObj2);

            }
            catch (Exception ex)
            {
                // info.  
                Console.Write(ex);
            }

            // info.  
            return lst;
        }

 

         
        /// <summary>  
        /// Get country method.  
        /// </summary>  
        /// <returns>Return country for drop down list.</returns>  
        private IEnumerable<SelectListItem> GetCountryList()
        {
            // Initialization.  
            SelectList lstobj = null;

            try
            {
                // Loading.  
                var list = this.LoadData()
                                  .Select(p =>
                                            new SelectListItem
                                            {
                                                Value = p.Country_Id.ToString(),
                                                Text = p.Country_Name
                                            });

                // Setting.  
                lstobj = new SelectList(list, "Value", "Text");
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            // info.  
            return lstobj;
        }

   

 
    }
    #endregion
}