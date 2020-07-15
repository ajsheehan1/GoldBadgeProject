using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    class ProgramUI
    {
        protected readonly ClaimsRepository claimsRepository = new ClaimsRepository();
        

        public void Run()
        {
            SeedQueueList();
            StartMenu();
        }

        private void StartMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("---- KOMODO CLAIMS ----");
                Console.WriteLine();

                Console.WriteLine("Welcome to KOMODO CLAIMS, please select from the options below: \n" +
                    " \n" +
                    "1. Show All Claims \n" +
                    "2. Take Care of Next Claim \n" +
                    "3. Enter a New Claim \n" +
                    "4. Exit");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        ShowClaims();
                        Console.Clear();
                        //We need to show all menu items
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        Console.Clear();
                        // Take care of next claim
                        break;
                    case "3":
                        EnterNewClaim();
                        Console.Clear();
                        // Enter new claim
                        break;
                    case "4":
                        // Exit 
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4 \n" +
                            "To continue, press any key");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void TakeCareOfNextClaim()
        {
            Console.WriteLine("---- KOMODO CLAIMS ----");
            Console.WriteLine();

            Console.WriteLine("Here is the next claim in the queue: \n" +
                "");
            Console.WriteLine("ClaimID: " + claimsRepository.directory.Peek().ClaimID);
            Console.WriteLine("Type: " + claimsRepository.directory.Peek().ClaimType);
            Console.WriteLine("Description: " + claimsRepository.directory.Peek().Description);
            Console.WriteLine("Amount: " + claimsRepository.directory.Peek().ClaimAmount);
            Console.WriteLine("Date of Accident: " + claimsRepository.directory.Peek().DateOfIncident.ToString("MM/dd/y"));
            Console.WriteLine("Date of Claim: " + claimsRepository.directory.Peek().DateOfClaim.ToString("MM/dd/y"));
            Console.WriteLine("IsValid: " + claimsRepository.directory.Peek().IsValid);

            Console.WriteLine();
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string userDecision = Console.ReadLine();

            if (userDecision == "y")
            {

                claimsRepository.DeleteClaimItems();

                Console.WriteLine("The claim has been removed. Thank you!");
                Console.ReadLine();
            } else if (userDecision == "n")
            {
                Console.WriteLine("The claim has been saved. Press any key to go back to the main menu.");
                Console.ReadLine();
                Console.Clear();
            } else
            {
                Console.WriteLine("Invalid selection. Press any key to return to the main menu.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void EnterNewClaim()
        {
            Console.WriteLine("---- KOMODO CLAIMS ----");
            Console.WriteLine();

            Claim claim = new Claim();
            
            
            Console.WriteLine("Enter the new claim ID number:");
            claim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What type of claim is this? Please select the number that corresponds with your type: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft");
            string claimTypeInput = Console.ReadLine();
            int claimID = int.Parse(claimTypeInput);
            claim.ClaimType = (ClaimType)claimID;
            Console.WriteLine();

            Console.WriteLine("Please enter a description: ");
            claim.Description = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Please enter the claim amount: ");
            claim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Please enter the date of the accident: (YYYY, MM, DD)");
            string dateOfIncidentInput = Console.ReadLine();
            claim.DateOfIncident = DateTime.Parse(dateOfIncidentInput);

            Console.WriteLine();
            Console.WriteLine("PLease enter the date of the claim file: (YYYY, MM, DD)");
            string dateofClaimInput = Console.ReadLine();
            claim.DateOfClaim = DateTime.Parse(dateofClaimInput);

            claimsRepository.AddClaimsToQueue(claim);
         
                   }

        private void ShowClaims()
        {
            Console.WriteLine("---- KOMODO CLAIMS ----");
            Console.WriteLine();
            

            Queue<Claim> claimQueue = claimsRepository.GetAllClaimContent();
            List<Claim> claimList = claimQueue.ToList();

            var header = String.Format("{0,-9}{1,-7}{2,-30}{3,-10}{4,-15}{5,-15}{6,-15}",
                              "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            Console.WriteLine(header);
            Console.WriteLine();
            foreach (Claim claim in claimList)
            {
                DisplayItems(claim);
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void SeedQueueList()
        {
            Claim itemOne = new Claim(1, ClaimType.Car, "Car accident on 465", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));

            Claim itemTwo = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));

            Claim itemThree = new Claim(3, ClaimType.Theft, "Stolen Pancakes.", 4, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));

            claimsRepository.AddClaimsToQueue(itemOne);
            claimsRepository.AddClaimsToQueue(itemTwo);
            claimsRepository.AddClaimsToQueue(itemThree);

        }

        private void DisplayItems(Claim claim)
        {

            string convertDollars = String.Format("{0:C2}", claim.ClaimAmount);
            var claimInfo = String.Format("{0,-9}{1,-7}{2,-30}{3,-10}{4,-15}{5,-15}{6,-15}",
                              claim.ClaimID, claim.ClaimType, claim.Description, convertDollars, claim.DateOfIncident.ToString("MM/dd/y"), claim.DateOfClaim.ToString("MM/dd/y"), claim.IsValid);
            Console.WriteLine(claimInfo);

        }

    }
}
