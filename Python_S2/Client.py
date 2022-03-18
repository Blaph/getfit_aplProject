import socket

_serverHost = '127.0.0.1'
_serverPort = 11000
_bufSize = 2048
_message = ""
_response = ""

while _message != "!exit":
    try:
        # Creiamo la socket (AF_INET = IPv4, SOCK_STREAM = TCP)
        serverSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        serverSocket.settimeout(5)
    except socket.error as err:
        print(f"Error while creating the socket!\nErr: {err}\n")
        
    print("Socket created.\n")
    
    try:
        # Ci colleghiamo tramite la socket appena aperta
        serverSocket.connect((_serverHost, _serverPort))
        print(f'Connected to the server: <{_serverHost}:{_serverPort}>.\n')
    except:
        print(f"Error! Cannot connect to the server <{_serverHost}:{_serverPort}>.\n")
        
    # Inizializziamo il messaggio da controllare

    try:
        _response = serverSocket.recv(_bufSize).decode()
        if _response != "":
            print(f"Response from <{_serverHost}:{_serverPort}>: {_response}")
        # Inseriamo il testo da inviare alla chat
        _message = input()
        # Codifichiamo in bytes il messaggio scritto
        serverSocket.send(_message.encode())
        print(f"Message sent: {_message}\n")
    except ConnectionAbortedError as err:
        print(f"{err}")
    except:
        print("Error while sending datas!\n")
    print(f"You succesfully exited from <{_serverHost}:{_serverPort}>.\n")
    serverSocket.close()
print("Program exited.\n")    
