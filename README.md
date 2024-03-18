MOH-LMIS: System Functionality Description

LMIS is a distributed system developed using a Microsoft SQL Server backend, Visual Basic .NET frontend, and Crystal Report for reporting. This system follows a client-server architecture, with each unit independently running a copy of LMIS and pushing the data to the national repository at MOH-HQ through an ADSL-VPN connection. In the event that a site is not connected via ADSL-VPN, the data is collected by taking backups of the respective databases. All the backups from the sites are then gathered at the LMIS unit located at the MOH headquarters.

Facility Level LMIS Systems

The national LMIS system consists of a central LMIS system located at the MOH Headquarters, which is connected to facility-level LMIS systems at National Referral Hospitals and all other health facilities through the corresponding MOH Zoba offices.
Each facility has a central system called the "Central Store," which is connected to the main national LMIS system at MOH-HQ. Additionally, there are satellite systems serving the Pharmacy, IRV, OPD, and Compound units. The satellite systems are utilized by these units to manage the status of medicine supply within their respective units, while also requesting replenishment from the central store system.
The satellite systems operate independently and traditionally pass the status data to the main store either via USB flash disk or printout copies of corresponding reports. The main store then updates manually based on the reports received from the satellite systems. However, at Halibet Hospital, a new wireless ICT infrastructure has been recently deployed, enabling direct accessibility of the satellite pharmacies by the central store. As a result, the central store can now collect updates remotely from the satellite systems via the network whenever necessary, and manually update the main database with the remotely accessed updates.

The National LMIS system

The 'Main Store' systems in hospitals and Zoba offices across the country send comprehensive reports to the National LMIS system at the MOH Headquarters by providing backup copies of the existing database. At the central LMIS system, updates from each remote site are manually incorporated, and the central system takes appropriate actions based on the need for further procurement of corresponding medicines from Pharmacore.
Currently, the database backups from every remote site (hospitals and Zoba offices) are collected manually and imported into a separate comprehensive LMIS reporting tool. This tool aggregates the reports at the national level to support decision-making. It is developed as a separate tool that complements the main LMIS system and provides comprehensive reports at both the national and facility levels, as required, to facilitate decision-making. The tool visually presents the reports as depicted in the following image:

In general, the national LMIS system does the following:

-	Manages the distribution of medicine to National referral Hospitals and all other health facilities through the corresponding MOH Zoba offices.
-	Collects Updates from every remote LMIS system and compile forecast for procurement
-	Prepares aggregate reports on Current Balance, Item level balance, Consumption at facility level and at National level and Facility Level balance from the remote LMIS backups to support decision making
-	The LMIS system in its current state satisfies the operational needs of the National Pharmacy division of the MOH, while automation of the national LMIS systems operations for timely reporting and real-time data/information access requires due attention and action.
