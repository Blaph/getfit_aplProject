import socket
from messageHandler import messageHandl

_serverHost = '127.0.0.1'
_serverPort = 11000
_bufSize = 2048

def main():
    try:
        # Creiamo un oggetto della classe messageHandler
        msgHandler = messageHandl()
    except:
        print("Error! Could not create the message handler!\n")
    
    try:
        # Creiamo la socket (AF_INET = IPv4, SOCK_STREAM = TCP)
        serverSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    except socket.error as err:
        print(f"Error while creating the socket!\nErr: {err}\n")
    print("Socket created.\n")
    
    try:
        serverSocket.bind((_serverHost, _serverPort)) # La socket prenderà dati da tutti i client in ascolto su 'serverHost'
        serverSocket.listen(5)      # Massimo 5 utenti nella chat
    except:
        print("Error while setting up the server!\n")
    print(f"Server running at: {_serverHost}.\nListenining on port {_serverPort}\n")
    
    while True:
        try:
            # Accettiamo la connessione
            client, addr = serverSocket.accept()
            print(f"Client <{addr}> connected!\n")
        except:
            print(f"Error!\nClient <{client}>\nAddr: <{addr}>\nClient could not connect to the server!\n")
            
        try:
            message = client.recv(_bufSize)
            print(f"Message received: {message}\n")
        except:
            print("Error! Cannot receive the incoming message from the client.\n")
            
        try:
            response = msgHandler.handleMessage(message)
        except:
            print("Error! Cannot handle the incoming message.\n")
        
        try:
            client.send(response)
        except:
            print("Error! Cannot receive messages from the server.\n")
            
        try:
            client.close()
        except:
            print("Error! Cannot close the client socket.\n")
    serverSocket.close()
    
# Eseguiamo il main del server
if __name__ == '__main__':
    main()