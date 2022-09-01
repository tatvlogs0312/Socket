package com.company;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	// write your code here

        Scanner sc = new Scanner(System.in);

        try {
            byte[] receiveData = new byte[1024];
            byte[] sendData = new byte[1024];

//            B1: tạo socket
            DatagramSocket sk = new DatagramSocket(8080);
            System.out.println("Run access !");

            while (true){
//            B2 : Nhận gói tin từ client
                DatagramPacket receivePacket = new DatagramPacket(receiveData,
                        receiveData.length);
                sk.receive(receivePacket);

//            B3 : Đọc và xử lý dữ liệu
                String message = new String(receivePacket.getData()).trim();
                System.out.println("- Client : " + message);

                if(message.contains("exit")){
                    String send = "exit";
                    sendData = send.getBytes();

                    InetAddress ipClient = receivePacket.getAddress();
                    int portClient = receivePacket.getPort();

                    DatagramPacket sendPacket = new DatagramPacket(sendData,
                            sendData.length,ipClient,portClient);

                    sk.send(sendPacket);
                    break;
                }

                System.out.print("Message : ");
                String send = sc.nextLine();
                sendData = send.getBytes();

//            B4 : Tạo packet gửi dữ liệu
                InetAddress ipClient = receivePacket.getAddress();
                int portClient = receivePacket.getPort();

                DatagramPacket sendPacket = new DatagramPacket(sendData,
                        sendData.length,ipClient,portClient);

//            B5 : Gửi gói tin đến client
                sk.send(sendPacket);

                if(send.contains("exit")){
                    break;
                }
            }

//            B6 : Đóng kết nối
            sk.close();

        } catch (Exception e) {
            System.out.println("Error : " + e.getMessage());
        }
    }
}
