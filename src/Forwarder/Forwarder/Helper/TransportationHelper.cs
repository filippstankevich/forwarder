﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForwarderDAL.Entity;

namespace Forwarder.Helper
{
    public class TransportationHelper
    {
        public int GetPlannedExpense(Transportation transportation)
        {
            int totalExpense = 0;
            if (transportation.Loads != null)
            {
                foreach (Load load in transportation.Loads)
                {
                    if (load.Expenses != null)
                    {
                        foreach (Expense expense in load.Expenses)
                        {
                            if (load.Method)
                            {
                                totalExpense += expense.Value * load.Volume * load.Count;
                            }
                            else
                            {
                                totalExpense += expense.Value * load.Count;
                            }
                        }
                    }
                }
            }

            return totalExpense;
        }

        public int GetPlannedPrice(Transportation transportation)
        {
            int price = 0;
            if (transportation.Loads != null)
            {
                foreach (Load load in transportation.Loads)
                {
                    if (load.Method)
                    {
                        price += load.Rate * load.Volume * load.Count;
                    }
                    else
                    {
                        price += load.Rate * load.Count;
                    }
                }
            }

            return price;
        }

        public int GetRealExpense(Transportation transportation)
        {
            int totalExpense = 0;
            if (transportation.Loads != null)
            {
                foreach (Load load in transportation.Loads)
                {
                    if (load.Expenses != null)
                    {
                        foreach (Expense expense in load.Expenses)
                        {
                            ICollection<Shipment> shipments = transportation.Shipments;
                            int count = shipments.Where(o => o.Weight == load.Volume).Count();

                            if (load.Method)
                            {
                                totalExpense += expense.Value * load.Volume * count;
                            }
                            else
                            {
                                totalExpense += expense.Value * count;
                            }
                        }
                    }
                }
            }

            return totalExpense;
        }

        public int GetRealPrice(Transportation transportation)
        {
            int price = 0;
            if (transportation.Loads != null)
            {
                foreach (Load load in transportation.Loads)
                {
                    ICollection<Shipment> shipments = transportation.Shipments;
                    int count = shipments.Where(o => o.Weight == load.Volume).Count();

                    if (load.Method)
                    {
                        price += load.Rate * load.Volume * count;
                    }
                    else
                    {
                        price += load.Rate * count;
                    }
                }
            }

            return price;
        }

    }
}