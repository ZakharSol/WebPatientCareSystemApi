# WebPatientCareSystemApi ~ ASP.NET WEB API
## Task:
- 2 controllers (Patients, Doctors):
  -    Insert record
  -   Update record
  -  Detele record
  -   Getting a list of records for a list form with sorting and pagination support
  -    Getting a record by key for editing
- The object returned by the method must be different from the object being edited

## DATABASE SCHEME:
  - Patients:
      - Id               (PK)
      - Firstname        (text)
      - Lastname         (text)
      - Patronymic       (text)
      - Address          (text)
      - Birthday         (DateTime - only date)
      - Gender           (enum - 0(Male),1(Female))
      - DistrictId       (FK)
  - Districts:
      - Id               (PK)
      - Number           (text)
  - Cabinets:
      - Id               (PK)
      - Number           (text)
  - Specializations:
      - Id               (PK)
      - Name             (text)
  - Doctors:
      - Id               (PK)
      - Fullname         (text)
      - CabinetId        (FK)
      - SpecializationId (FK)
      - DistrictId       (FK)

## How to:
After running the project via the .sln file, you need to go to the NuGet package console, and then initialize the ```Update-Database``` command. After these steps, you can start testing this product: you need to debug or build, after this action, a web page will be launched, which contains methods for testing by means of swagger.
