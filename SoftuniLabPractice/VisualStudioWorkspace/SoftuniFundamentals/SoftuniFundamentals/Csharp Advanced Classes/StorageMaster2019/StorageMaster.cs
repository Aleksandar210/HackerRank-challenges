﻿using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace SoftuniFundamentals.Csharp_Advanced_Classes.StorageMaster2019
{
    public class StorageMaster : IStorageMaster
    {
        //resources
        StringBuilder sb;

        //fields
        private List<Product> productPool;
        private Dictionary<string, Storage> storagePool;
        private Vehicle currentVehicle;
        public StorageMaster()
        {
            this.productPool = new List<Product>();
            this.storagePool = new Dictionary<string, Storage>();
            this.sb = new StringBuilder();
        }

        public string AddProduct(string type, double price)
        {
            switch(type.ToLower())
            {
                case "ram":
                    this.productPool.Add(new Ram(price));
                    break;
                case "gpu":
                    this.productPool.Add(new Gpu(price));
                    break;
                case "harddrive":
                    this.productPool.Add(new HardDrive(price));
                    break;
                case "solidstatedrive":
                    this.productPool.Add(new SolidStateDrive(price));
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
                    
            }

            return $"Added {type} to pool.";
        }

        public string GetStorageStatus(string storageName)
        {
            if(this.storagePool.ContainsKey(storageName))
            {
                return this.storagePool[storageName].ToString();
            }
            else
            {
                throw new InvalidOperationException("Storage not foudn in pool.");
            }
            

        }

        public string GetSummary()
        {
            
            this.storagePool = this.storagePool.OrderByDescending(item => item.Value.GetStorageTotalPrice).ToDictionary(e=>e.Key,e=>e.Value);
            foreach(var item in this.storagePool)
            {
                this.sb.Append($"{item.Key}" + Environment.NewLine + $"Storage worth: ${item.Value.GetStorageTotalPrice}");
            }

            return this.sb.ToString();
        }

        public string LoadVehicle(IEnumerable<Product> products)
        {
            return null;
        }

        public string RegisterStorage(string type, string name)
        {
            switch(type.ToLower())
            {
                case "warehouse":
                    if(!this.DoesNameExistInPool(name))
                    {
                        this.storagePool.Add(name, new Warehouse(name));
                    }
                    break;
                case "automatedwarehouse":
                    if (!this.DoesNameExistInPool(name))
                    {
                        this.storagePool.Add(name, new AutomatedWarehouse(name));
                    }
                    break;
                case "distributioncenter":
                    if (!this.DoesNameExistInPool(name))
                    {
                        this.storagePool.Add(name, new DistributionCenter(name));
                    }
                    break;
                default:
                    throw new InvalidOperationException("Invalid type.");
                   
            }

            return $"Registered {name}.";
        }

        private bool DoesNameExistInPool(string name)
        {
            if(this.storagePool.ContainsKey(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            if(this.storagePool.ContainsKey(storageName))
            {
               if(this.storagePool[storageName].Garage[garageSlot] is null)
                {
                    throw new InvalidOperationException($"No vehicle found in {garageSlot} garage slot");
                }
                else
                {
                    this.currentVehicle = this.storagePool[storageName].GetVehicle(garageSlot);
                    return $"Selected {currentVehicle.GetType().Name}.";
                }
            }
            else
            {
                throw new InvalidOperationException("Storage not found.");
            }
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            string vehicleType = null;
            if(this.storagePool.ContainsKey(sourceName))
            {
                if(this.storagePool.ContainsKey(destinationName))
                {
                    if((this.storagePool[sourceName].Garage[sourceGarageSlot] is null))
                    {
                        vehicleType = this.storagePool[sourceName].Garage[sourceGarageSlot].GetType().Name;
                    }
                   this.storagePool[sourceName].SendVehicleTo(sourceGarageSlot,this.storagePool[destinationName]);
                    return $"{vehicleType} send from {sourceName} to {destinationName}";
                }
                else
                {
                    throw new InvalidOperationException($"No storage found by the name {destinationName}");
                }
            }
            else
            {
                throw new InvalidOperationException($"No storage found by the name {sourceName}");
            }
        }

       

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            int numberProductsUnloaded = 0;
            if(this.storagePool.ContainsKey(storageName))
            {
                while(true)
                {
                    try
                    {
                        this.storagePool[storageName].UnloadVehicle(garageSlot);
                        numberProductsUnloaded += 1;
                    }
                    catch(InvalidOperationException exc)
                    {

                    }
                   
                    
                }
               
            }
            else
            {
                throw new InvalidOperationException($"No storage with name {storageName} was found.");
            }
        }
    }
}