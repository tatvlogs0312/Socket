package com.company;

import java.net.*;
import java.io.*;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        // write your code here
        Scanner sc = new Scanner(System.in);

        try {
//           TODO : B1 - Tạo socket server
            ServerSocket sk = new ServerSocket(8080);

//           TODO: B2 - Chờ 1 kết nối
            System.out.println("Chờ kết nối từ client . . .");
            Socket s = sk.accept();
            System.out.println("Có 1 kết nối từ client : " + s.getInetAddress());

//            TODO : B3 - Thực hiện gửi nhận với client
//            Dữ liệu gửi
            PrintWriter out = new PrintWriter(new OutputStreamWriter(s.getOutputStream()));

//            Dữ liệu nhận
            BufferedReader in = new BufferedReader(new InputStreamReader(s.getInputStream()));

//            TODO : B3.1 - Nhận dữ liệu của client
            while (true) {
                String message = in.readLine();
                System.out.println("- Client : " + message);
//            String send = "Thông điệp gửi cho client : " + message.toUpperCase();

                if(message.equals("exit")){
                    String exit = "exit";
                    out.println(exit);//Lưu thông điệp vào bộ nhớ đệm
                    out.flush();//Gửi thông điệp
                    break;
                }

//            TODO : B3.2 - Gửi dữ liệu cho client
                System.out.print("Message : ");
                String msg = sc.nextLine();

                out.println(msg);//Lưu thông điệp vào bộ nhớ đệm
                out.flush();//Gửi thông điệp

                if(msg.equals("exit")){
                    break;
                }
            }


//            TODO : B4 - Đóng kết nối
            in.close();
            out.close();
            s.close();

        } catch (Exception e) {
            System.out.println("Error : " + e.getMessage());
        }
    }
}
