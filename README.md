# getfit_aplProject (SISTEMARE)
University project for the Advanced Programming Languages course. 2021/2022

----- DESCRIZIONE DELL'APPLICAZIONE -----
GetFit è un'applicazione nata per aiutare i salutisti a mantenersi in forma.
Tramite l'iscrizione, si accede ad una dashboard personalizzata in cui sono mostrati:
- il fabbisogno calorico giornaliero
- alcuni dati personali
- due pulsanti per visualizzare le ricette e gli ingredienti caricati nel database
- un pulsante per generare un menù casuale che, in base a dei criteri, mostra dei piatti consigliati da consumare le quali kcal,
	sommate, rientrano all'interno di quelle del fabbisogno giornaliero considerando un certo margine di errore
Cliccando su una ricetta o su un ingrediente dell'apposita lista, si apre una schermata riepilogativa in cui sono contenute
le caratteristiche della ricetta o dell'ingrediente scelto, oltre alla possibilità di aggiungerlo (o rimuoverlo) tra i propri preferiti.
La scelta randomica del menù si basa proprio sugli ingredienti preferiti scelti, per cui è inserito un controllo in modo da consigliare
l'utente di aggiungerli.

L'applicazione, reperibile alla seguente repository pubblica su github:

https://github.com/Blaph/getfit_aplProject

consiste in: 
- un client scritto interamente in C#, con interfaccia grafica
- un server scritto interamente in Python, incentrato sull'esecuzione di operazioni statistiche e in particolare, con l'ausilio delle libreria numpy, di generare un menù randomico consigliato.
- un server scritto interamente in GO, il quale scopo principale è quello di interagire con il database e fungere da mediatore tra il client
 e il server python.

La comunicazione client-server avviene tramite socket implementate grazie alle librerie dei rispettivi linguaggi di programmazione ed avviene in localhost, su 127.0.0.1. Porta :10000 per la comunicazione C# -> GO e porta :11000 per la comunicazione GO -> Python


----- ESECUZIONE DELL'APPLICAZIONE -----
L'applicazione è stata progettata per essere eseguita in questo ordine:
1. Avvio del db e caricamento dei dati iniziali
2. Avvio del server Python
3. Avvio del server Go
4. Avvio del client in C#


----- STRUTTURA DELL'APPLICAZIONE -----
La struttura gerarchica è così costruita:

Progetto finale (repository)/
├─ C#_Client/
│  ├─ getfit_clientGUI (cartella del progetto per il client in C#)
│  │   ├─ getfit_clientGUI
│  │   ├─ getfit_clientGUI.sln (file del progetto, da utilizzare per eseguire il client)
├─ GO_S1/ (cartella del progetto per il server in GOlang)
│  ├─ client
│  │   ├─ client.go (codice per eseguire il client di test in GOlang, che di fatto non viene utilizzato nella versione finale del progetto)
│  ├─ dbmanager
│  │   ├─ dbmanager.go (contiene tutte le operazioni che eseguono le query al db)
│  ├─ server
│  │   ├─ client.go (codice per eseguire il server in GOlang)
│  ├─ go.mod
│  ├─ go.sum
├─ Python_S2 (cartella del progetto per il server in Python)
│  ├─ Calculator.py (esegue le operazioni statistiche e si occupa di estrarre i tre piatti che andranno a formare il menù giornaliero)
│  ├─ Client.py (client di test in python, che non viene utilizzato nella versione finale del progetto)
│  ├─ messageHandler.py (gestisce le operazioni da eseguire quando viene ricevuta una richiesta)
│  ├─ Server.py (codice per eseguire il server in python)
├─ dbSetup.sql (base di dati, caricata in un server MySQL anch'esso in localhost, porta :3306, usata per riempire il database prima 	dell'esecuzione del progetto)
