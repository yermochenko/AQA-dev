using lab_3.Domain;
using lab_3.Json;
using lab_3.Logic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace lab_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddFilter("lab_3.Program", LogLevel.Debug).AddConsole());
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Application started.");
            var dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = $"{dirPath}{Path.DirectorySeparatorChar}info.json";
            StreamReader streamReader = null;
            try
            {
                logger.LogDebug("Trying to read file \"{1}\".", filePath);
                streamReader = new StreamReader(filePath);
                var json = streamReader.ReadToEnd();
                const int limit = 426;
                logger.LogDebug($"Content of the file (first {limit} symbols):\n{json.Substring(0, limit)}\n");
                var mobilePhoneStoreChain = JsonReader.Read(json);
                logger.LogDebug($"Shop list:\n{string.Join("\n", mobilePhoneStoreChain.Shops)}");
                var shops = mobilePhoneStoreChain.AvailableMobilePhones();
                string output = null;
                output = $"List of available mobile phones:";
                foreach (var shopEntry in shops)
                {
                    output += $"\nShop ID #{shopEntry.Key.Id} \"{shopEntry.Key.Name}\"\n{shopEntry.Key.Description}";
                    foreach (var phoneEntry in shopEntry.Value)
                    {
                        output += $"\n    {phoneEntry.Key, -10} - {phoneEntry.Value.Count} available phones";
                    }
                }
                logger.LogInformation(output);
                var phoneFound = false;
                List<MobilePhone> phones = null;
                string phoneModel = null;
                while (!phoneFound)
                {
                    logger.LogInformation("Which mobile phone do you want to buy?");
                    phoneModel = Console.ReadLine();
                    try
                    {
                        phones = mobilePhoneStoreChain.AvailableMobilePhones(phoneModel);
                        phoneFound = true;
                    }
                    catch (AvailableMobilePhonesNotFoundException)
                    {
                        logger.LogWarning("This mobile phone is out of stock");
                    }
                    catch (MobilePhonesNotFoundException)
                    {
                        logger.LogWarning("This mobile phone is not found");
                    }
                }
                output = $"List of found mobile phones:";
                foreach (var phone in phones)
                {
                    output += $"\n{phone.Model} ({phone.OperationSystemType}), price ${phone.Price}, market launch date {phone.MarketLaunchDate:MM.yyyy}, available in shop \"{phone.Shop.Name}\"";
                }
                logger.LogInformation(output);
                var shopFound = false;
                while (!shopFound)
                {
                    logger.LogInformation($"In which store do you want to buy the mobile phone {phoneModel}?");
                    var shopName = Console.ReadLine();
                    try
                    {
                        phones = mobilePhoneStoreChain.AvailableMobilePhones(phoneModel, shopName);
                        shopFound = true;
                    }
                    catch (ShopNotFoundException)
                    {
                        logger.LogWarning("This shop is not found");
                    }
                }
                var orderedPhone = phones[0];
                logger.LogInformation($"Order for {orderedPhone.Model} ({orderedPhone.OperationSystemType}), price ${orderedPhone.Price}, market launch date {orderedPhone.MarketLaunchDate:MM.yyyy}, in shop \"{orderedPhone.Shop.Name}\" has been successfully placed.");
            }
            catch (DirectoryNotFoundException)
            {
                logger.LogCritical("Path \"{1}\" is not found.", dirPath);
            }
            catch (FileNotFoundException)
            {
                logger.LogCritical("File \"{1}\" is not found.", filePath);
            }
            catch (IOException)
            {
                logger.LogCritical("File \"{1}\" can not be readed.", filePath);
            }
            catch (ArgumentException e)
            {
                logger.LogCritical(e.Message);
            }
            catch (Exception e) when (e is FormatException || e is JsonException)
            {
                logger.LogCritical("JSON file \"{1}\" has incorrect format.", filePath);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            logger.LogInformation("Application stopped.");
        }
    }
}
