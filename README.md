Hospital Management System (HMS) (Phase 1)
Console Application with Entity Framework
1. Project Overview
The Hospital Management System (HMS) is a console application designed to manage basic hospital operations such as:
●	Patient registration and management.
●	Doctor management.
●	Appointment scheduling.
●	Prescription and medication management.
●	Automatic billing when a prescription is issued.
This version uses Entity Framework Core with Microsoft SQL Server and follows the Code-First Approach.
________________________________________
2. Key Features
The application will include the following core functionalities:
Core Functionalities
1.	Patient Management
o	Register new patients.
o	View and update patient details.
o	Delete patient records.
2.	Doctor Management
o	Add new doctors.
o	View and update doctor details.
o	Delete doctor records.
3.	Doctor Specialties Management
o	Add new specialties.
o	Assign specialties to doctors.
o	View and update specialties.
4.	Appointment Management
o	Schedule appointments between patients and doctors.
o	View all appointments by doctor id or patient id.
o	Cancel appointments.
5.	Prescription Management
o	Issue prescriptions to patients.
o	View and update prescriptions.
o	Automatically generate a bill when a prescription is created.
6.	Medication Management
o	Add new medications.
o	View and update medication details.
o	Track medication inventory.
7.	Billing Management
o	View and update billing details.
o	Bills are automatically generated when prescriptions are issued.
________________________________________
3. Entities and Properties
Below are the entities and their properties. The entities are designed to demonstrate the three types of relationships.
1. Patient
●	PatientId (int): Primary key, auto-incremented.
●	Name (string): Full name of the patient.
●	Age (int): Age of the patient.
●	Gender (string): Gender of the patient.
●	ContactNumber (string): Contact number of the patient.
●	Address (string): Address of the patient.
●	Relationships:
o	A patient can have many appointments.
o	 A patient can have many prescriptions.
o	 A patient can have many bills.
2. Doctor
●	DoctorId (int): Primary key, auto-incremented.
●	Name (string): Full name of the doctor.
●	Age (int): Age of the doctor.
●	Gender (string): Gender of the doctor.
●	ContactNumber (string): Contact number of the doctor.
●	Email (string): Email address of the doctor.
●	Specialty (string): the Specialty of the doctor.
●	Relationships:
o	A doctor can have many appointments.
o	 A doctor can issue many prescriptions.
4. Appointment
●	AppointmentId (int): Primary key, auto-incremented.
●	AppointmentDate (DateTime): Date and time of the appointment.
●	Status (string): Status of the appointment ( Scheduled, Completed, Canceled).
5. Prescription
●	PrescriptionId (int): Primary key, auto-incremented.
●	PrescriptionDate (DateTime): Date the prescription was issued.
●	Relationships:
o	A prescription can have many medications.
o	A prescription will be for one Patient and doctor
6. Medication
●	MedicationId (int): Primary key, auto-incremented.
●	Name (string): Name of the medication.
●	Quantity (int): Quantity of the medication in stock.
●	Price (decimal): Price per unit of the medication.
●	Relationships:
o	A medication can have many prescriptions.
7. Bill
●	BillId (int): Primary key, auto-incremented.
●	PatientId (int): Foreign key referencing Patient.
●	PrescriptionId (int): Foreign key referencing Prescription.
●	Amount (decimal): Total amount of the bill.
●	BillDate (DateTime): Date the bill was generated.
●	Status (string): Status of the bill (e.g., Paid, Unpaid).
●	Relationships:
o	A bill is associated with one prescription.
________________________________________
5. Execution Scenario
Below is a step-by-step execution scenario for the application:
Step 1: Menu Design
The application will display a console-based menu with the following options:
1.	Patient Management
o	Add Patient
o	View Patients
o	Update Patient
o	Delete Patient
2.	Doctor Management
o	Add Doctor
o	View Doctors
o	Update Doctor
o	Delete Doctor
3.	Appointment Management
o	Schedule Appointment
o	View Appointments
o	Cancel Appointment
4.	Prescription Management
o	Issue Prescription
o	View Prescriptions
5.	Medication Management
o	Add Medication
o	View Medications
6.	Billing Management
o	View Bills
7.	Exit
Step 3: Add Patient
1.	The user selects Add Patient from the menu.
2.	The application prompts the user to enter patient details (Name, Age, Gender, ContactNumber, Address).
3.	The application saves the patient to the database using EF Core.
Step 4: Add Doctor
1.	The user selects Add Doctor from the menu.
2.	The application prompts the user to enter patient details (Name, Age, Gender, ContactNumber, Address, Email, Specialty). 
3.	The application saves the doctor to the database using EF Core.
Step 4: Schedule Appointment
1.	The user selects Schedule Appointment from the menu.
2.	The application prompts the user to enter:
o	Patient ID
o	Doctor ID
o	Appointment Date
3.	The application saves the appointment to the database using EF Core.
Step 5: Issue Prescription
1.	The user selects Issue Prescription from the menu.
2.	The application prompts the user to enter:
o	Patient ID
o	Doctor ID
o	Medication ID
3.	The application saves the prescription to the database using EF Core.
4.	Automatically generate a bill for the prescription:
o	The bill amount is calculated based on the prescription medications price.
o	The bill is saved to the database with a status of "Unpaid".
Step 6: View Bills
1.	The user selects View Bills from the menu.
2.	The application retrieves and displays all bills from the database.
Step 7: Exit
1.	The user selects Exit from the menu.
2.	The application terminates.
________________________________________
6. Deliverables
you should submit the following:
1.	Source Code: The complete .NET console application________________________________________
