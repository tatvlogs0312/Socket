package com.company;

import java.io.*;
import java.net.*;
import java.util.Scanner;

public class Main {

    public static void main(String[] args){

        try {
//            TODO : B1 - Kết nối đến server
            Socket s = new Socket("localhost",8080);
            System.out.println("Connect access to server");

//            TODO : B2 - Thực hiện gửi nhận đến server

//            Thực hiện kịch bản
//            Dữ liệu gửi
            PrintWriter out = new PrintWriter(new OutputStreamWriter(s.getOutputStream()));

//            Dữ liệu nhận
            BufferedReader in = new BufferedReader(new InputStreamReader(s.getInputStream()));

//            TODO : B2.1 : Gửi thông điệp
            Scanner sc = new Scanner(System.in);
            while(true){
                System.out.print("Message : ");
                String send = sc.nextLine();

                out.println(send);//Lưu thông điệp vào bộ nhớ đệm
                out.flush();//Gửi thông điệp

//            TODO : B2.2 : Nhận thông điệp
                String message = in.readLine();
                System.out.println("- Server : " + message);

                if(message.equals("exit")){
                    break;
                }
            }

//            TODO : B3 - Đóng kết nối
            in.close();
            out.close();
            s.close();

        } catch (Exception e) {
            System.out.println("Connect failed to server because : " + e.getMessage());

        }

    }
}
