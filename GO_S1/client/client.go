package client

import (
	"fmt"
	"net"
)

const (
	SERVER_HOST = "127.0.0.1"
	SERVER_PORT = "11000"
	SERVER_TYPE = "tcp"
	BUF_SIZE    = 2048
)

func SendMessage(message string) string {
	conn, err := net.Dial(SERVER_TYPE, SERVER_HOST+":"+SERVER_PORT)
	if err != nil {
		fmt.Println("Error connecting to the server. Error: ")
		panic(err.Error())
	}
	defer conn.Close()

	_, err = conn.Write([]byte(message)) // Inviamo il messaggio col comando, al server python
	if err != nil {
		fmt.Println("Error while sending messages to the server. Error: ")
		panic(err.Error())
	}

	buffer := make([]byte, BUF_SIZE)
	messageLen, err := conn.Read(buffer)
	if err != nil {
		fmt.Println("Error while reading incoming response. Error: ")
		panic(err.Error())
	}
	response := string(buffer[:messageLen])
	fmt.Println("Response received: ", response)
	return response
}
