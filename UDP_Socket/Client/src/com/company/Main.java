package com.company;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	// write your code here

        Scanner sc = new Scanner(System.in);

        try {
            byte[] receiveData = new byte[1024];
            byte[] sendData = new byte[1024];

//            B1 : Tạo socket
            DatagramSocket sk = new DatagramSocket(8081);
            System.out.println("Connect access to server !");

            while (true){
//            B2 : Tạo packet
                System.out.print("Message : ");
                String send = sc.nextLine();
                sendData = send.getBytes();
                InetAddress ipServer = InetAddress.getByName("localhost");
                int portServer = 8080;
                DatagramPacket sendPacket = new DatagramPacket(sendData,
                        sendData.length,ipServer,portServer);

//            B3 : Gửi packet đến server
                sk.send(sendPacket);

//            B4 : Nhận packet từ server
                DatagramPacket receivePacket = new DatagramPacket(receiveData,
                        receiveData.length);
                sk.receive(receivePacket);

//            B5 : Đọc dữ liệu từ packet
                String message = new String(receivePacket.getData()).trim();
                System.out.println("- Server : " + message);

                if(message.contains("exit")){
                    break;
                }
            }

//            B6 : Đóng kết nối
            sk.close();

        }  catch (Exception e) {
            System.out.println("Error : " + e.getMessage());
        }


    }
}
