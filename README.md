**Note:** This is an old school project done in collaboration with other students. None of use really knew git back then, not were we particularly..disciplined, in its usage. Don't judge me too hard.

Repository exists for archival purposes only.

For this project, we decided to write our own data access layer, instead of using an ORM, for which I was responsible.

* [Raunstrup.Data](Raunstrup/Raunstrup.Data/) contains the repository interfaces.
* [Raunstrup.Data.InMemory](Raunstrup/Raunstrup.Data.InMemory/) contains a simplistic in-memory implementation for testing/prototyping.
* [Raunstrup.Data.MsSql](Raunstrup/Raunstrup.Data.MsSql/) contains an implementation for MSSQL Server.

Regrets:

* Using a generic repository pattern - I've come to dislike this pattern a lot.
* Explicitly defined datamappers and proxy/ghost objects - these should have been made in a smarter more generic way.

---

```
 _____    _____   _     _  _     _   _____  _______  _____   _     _  _____   
(_____)  (_____) (_)   (_)(_)   (_) (_____)(__ _ __)(_____) (_)   (_)(_____)  
(_)__(_)(_)___(_)(_)   (_)(__)_ (_)(_)___     (_)   (_)__(_)(_)   (_)(_)__(_) 
(_____) (_______)(_)   (_)(_)(_)(_)  (___)_   (_)   (_____) (_)   (_)(_____)  
( ) ( ) (_)   (_)(_)___(_)(_)  (__)  ____(_)  (_)   ( ) ( ) (_)___(_)(_)      
(_)  (_)(_)   (_) (_____) (_)   (_) (_____)   (_)   (_)  (_) (_____) (_)   
```

Opsætnings instruktioner:

1. Opret ny SQL Server database kaldet "Raunstrup"
2. Kør SQL filen "sql/schema.sql"
3. Evt. opret test data vha. "sql/data.sql"
4. Kør release versionen af "Raunstrup.Forms" projektet
