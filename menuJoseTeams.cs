using System;
using System.Collections.Generic;

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
				Console.WriteLine("Au revoir!");
				break;

				default:
				Console.WriteLine("Choix invalide. Veuillez réessayer.");
				break;
			}         
		} 
		while (choixMenu != 0);     
	}

	// Méthode pour saisir les détails d'une offre    
	static Offre SaisirOffre()    
	{
		Offre nouvelleOffre = new Offre();
		Console.Write("Destination: ");
		nouvelleOffre.destination = Console.ReadLine();
		Console.Write("Transport (air/mer/terrestre): ");
		nouvelleOffre.transport = Console.ReadLine();
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
			Console.WriteLine($"Nom: {reservation.nomClient}, Prénom: {reservation.prenomClient}, Téléphone: {reservation.numTelephone}");
			Console.WriteLine($"Offre choisie: {reservation.offreChoisie.destination}\n"); 
		}
	}
}
