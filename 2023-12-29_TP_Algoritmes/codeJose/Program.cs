using System;
using System.Collections.Generic;

namespace codeJose
{
	class Program
	{
		// Structure de données pour stocker les détails de l'offre    

		struct Offre
		{
			public string destination;
			public string transport;
			public double prixTransport;
			public int dureeVoyage;
			public string compagnieTransport;
			public int nombreEtoiles;
			public double prixNuit;
			public string nomHotel;
			public string loisir;
			public double coutLoisir;
		}
		// Structure de données pour stocker les détails de la réservation    

		struct Reservation
		{
			public string nomClient;
			public string prenomClient;
			public string numTelephone;
			public Offre offreChoisie;
		}

		static void Main()
		{
			// Initialisation des listes pour stocker les offres et les réservations        
			List<Offre> offres = new List<Offre>();
			List<Reservation> reservations = new List<Reservation>();
			bool exit = true;
			int choixMenu;

			do
			{
				// Affichage du menu            
				Console.WriteLine("\nMenu:");
				Console.WriteLine("1. Ajouter une offre");
				Console.WriteLine("2. Effectuer une réservation");
				Console.WriteLine("3. Afficher les réservations de la journée");
				Console.WriteLine("0. Quitter");
				// Saisie du choix de l'utilisateur            
				Console.Write("Choix: ");
				choixMenu = Convert.ToInt32(Console.ReadLine());
				// Traitement du choix de l'utilisateur            
				switch (choixMenu)
				{
					case 1:
						// Saisie des détails de l'offre
						Offre nouvelleOffre = SaisirOffre();
						offres.Add(nouvelleOffre);
						break;

					case 2:
						// Saisie des détails de la réservation                    
						Reservation nouvelleReservation = SaisirReservation(offres);
						reservations.Add(nouvelleReservation);
						break;

					case 3:
						// Affichage des réservations de la journée                    
						AfficherReservations(reservations);
						break;

					case 0:
						// Quitter le programme                    
						exit = false;
						break;

					default:
						Console.WriteLine("Choix invalide. Veuillez réessayer.");
						break;
				}
			} while (exit);
		}

		// Méthode pour saisir les détails d'une offre    
		static Offre SaisirOffre()
		{
			bool exit = false;
			int choixTransport;
			Offre nouvelleOffre = new Offre();
			Console.Clear();
			Console.Write("Destination: ");
			nouvelleOffre.destination = Console.ReadLine(); 
			do
			{
				Console.WriteLine("Choisisr une offre");
				Console.WriteLine("1. air");
				Console.WriteLine("2. mer");
				Console.WriteLine("3. terrestre");
				choixTransport = Convert.ToInt16(Console.ReadLine());
				switch (choixTransport)
				{
					case 1:
						nouvelleOffre.transport = "air";
						exit = true;
						Console.Clear();
						break;
					case 2:
						nouvelleOffre.transport = "mer";
						exit = true;
						Console.Clear();
						break;
					case 3:
						nouvelleOffre.transport = "terrestre";
						exit = true;
						Console.Clear();
						break;
					default:
						Console.WriteLine("Saisir une chiffre valide");
						Console.Clear();
						break;
				}
			} while (!exit);

			//nouvelleOffre.transport = choixTransport;
			Console.Write("Prix total du transport: ");
			nouvelleOffre.prixTransport = Convert.ToDouble(Console.ReadLine());
			Console.Write("Durée du voyage (en jours): ");
			nouvelleOffre.dureeVoyage = Convert.ToInt32(Console.ReadLine());
			Console.Write("Nom de la compagnie de transport: ");
			nouvelleOffre.compagnieTransport = Console.ReadLine();
			Console.Write("Nombre d'étoiles de l'hôtel: ");
			nouvelleOffre.nombreEtoiles = Convert.ToInt32(Console.ReadLine());
			Console.Write("Prix de la nuitée à l'hôtel: ");
			nouvelleOffre.prixNuit = Convert.ToDouble(Console.ReadLine());
			Console.Write("Nom de l'hôtel: ");
			nouvelleOffre.nomHotel = Console.ReadLine();
			Console.Write("Description du loisir: ");
			nouvelleOffre.loisir = Console.ReadLine();
			Console.Write("Coût du loisir: ");
			nouvelleOffre.coutLoisir = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Offre ajoutée avec succès!");
			Console.WriteLine("Appuyez sur n'importe quelle touche pour continuer.");
			Console.ReadKey();
			Console.Clear();
			return nouvelleOffre;
		}

		// Méthode pour saisir les détails d'une réservation    

		static Reservation SaisirReservation(List<Offre> offresDisponibles)
		{
			Reservation nouvelleReservation = new Reservation();
			Console.Write("Nom du client: ");
			nouvelleReservation.nomClient = Console.ReadLine();
			Console.Write("Prénom du client: ");
			nouvelleReservation.prenomClient = Console.ReadLine();
			Console.Write("Numéro de téléphone du client: ");
			nouvelleReservation.numTelephone = Console.ReadLine();
			// Affichage des offres disponibles        
			Console.WriteLine("\nOffres Disponibles:");
			for (int i = 0; i < offresDisponibles.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {offresDisponibles[i].destination}");
			}

			// Sélection de l'offre
			Console.Write("Choix de l'offre (numéro): ");
			int choixOffre = Convert.ToInt32(Console.ReadLine()) - 1;
			if (choixOffre >= 0 && choixOffre < offresDisponibles.Count)
			{
				nouvelleReservation.offreChoisie = offresDisponibles[choixOffre];
				Console.WriteLine("Réservation effectuée avec succès!");
			}
			else
			{
				Console.WriteLine("Choix d'offre invalide.");
			}

			return nouvelleReservation;
		}

		// Méthode pour afficher les réservations de la journée    
		static void AfficherReservations(List<Reservation> reservations)
		{
			Console.WriteLine("\nRéservations de la journée:");
			foreach (var reservation in reservations)
			{
				Console.WriteLine(
					$"Nom: {reservation.nomClient}, Prénom: {reservation.prenomClient}, Téléphone: {reservation.numTelephone}");
				Console.WriteLine($"Offre choisie: {reservation.offreChoisie.destination}\n");
			}
		}
	}
}

/*
class TravelAgencyManagement
{
    class Offer
    {
        public string destination;
        public string transport;
        public string accommodation;
        public string leisure;
    }

    class Reservation
    {
        public string clientFirstName;
        public string clientLastName;
        public string clientPhoneNumber;
        public Offer chosenOffer;
    }

    static List<Offer> offers = new List<Offer>();
    static List<Reservation> reservations = new List<Reservation>();

    static void AddOffer(string destination, string transport, string accommodation, string leisure)
    {
        Offer newOffer = new Offer();
        newOffer.destination = destination;
        newOffer.transport = transport;
        newOffer.accommodation = accommodation;
        newOffer.leisure = leisure;
        offers.Add(newOffer);
    }

    static void MakeReservation(string clientFirstName, string clientLastName, string clientPhoneNumber, Offer chosenOffer)
    {
        Reservation newReservation = new Reservation();
        newReservation.clientFirstName = clientFirstName;
        newReservation.clientLastName = clientLastName;
        newReservation.clientPhoneNumber = clientPhoneNumber;
        newReservation.chosenOffer = chosenOffer;
        reservations.Add(newReservation);
    }

    static void ListSoldOffers()
    {
        foreach (Reservation reservation in reservations)
        {
            Console.WriteLine($"Client: {reservation.clientFirstName} {reservation.clientLastName}, Phone: {reservation.clientPhoneNumber}, Offer: {reservation.chosenOffer.destination}");
        }
    }

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("Travel Agency Management System Menu:");
            Console.WriteLine("1. Add new offer");
            Console.WriteLine("2. Make reservation");
            Console.WriteLine("3. List sold offers");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter destination: ");
                    string destination = Console.ReadLine();
                    Console.Write("Enter transport: ");
                    string transport = Console.ReadLine();
                    Console.Write("Enter accommodation: ");
                    string accommodation = Console.ReadLine();
                    Console.Write("Enter leisure: ");
                    string leisure = Console.ReadLine();
                    AddOffer(destination, transport, accommodation, leisure);
                    break;
                case 2:
                    Console.Write("Enter client's first name: ");
                    string clientFirstName = Console.ReadLine();
                    Console.Write("Enter client's last name: ");
                    string clientLastName = Console.ReadLine();
                    Console.Write("Enter client's phone number: ");
                    string clientPhoneNumber = Console.ReadLine();
                    Console.Write("Enter chosen offer destination: ");
                    string chosenOfferDestination = Console.ReadLine();
                    Offer chosenOffer = offers.Find(o => o.destination == chosenOfferDestination);
                    if (chosenOffer != null)
                    {
                        MakeReservation(clientFirstName, clientLastName, clientPhoneNumber, chosenOffer);
                    }
                    else
                    {
                        Console.WriteLine("Offer not found.");
                    }
                    break;
                case 3:
                    ListSoldOffers();
                    break;
                case 4:
                    Console.WriteLine("Exiting the system. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        } while (choice != 4);
    }
}
*/
