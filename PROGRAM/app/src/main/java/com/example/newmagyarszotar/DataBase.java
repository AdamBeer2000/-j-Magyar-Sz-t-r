package com.example.newmagyarszotar;

import java.sql.Connection;
import java.sql.DatabaseMetaData;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class DataBase
{
    final String URL = "jdbc:sqlserver://the-first-git-emire.database.windows.net:1433;database=NewMagyarSzotar;";//jdbc:sqlserver://the-first-git-emire.database.windows.net:1433;database=NewMagyarSzotar
    final String USERNAME = "pistabacsi";
    final String PASSWORD = "Nemezajelszo1";
    public String msg = "pending";

    //Létrehozzuk a kapcsolatot (hidat)
    Connection conn = null;
    Statement createStatement = null;
    DatabaseMetaData dbmd = null;

    public DataBase()
    {
        //Megpróbáljuk életre kelteni
        try {
            conn = DriverManager.getConnection(URL, USERNAME, PASSWORD);
            msg = "CONNECTED";
        } catch (SQLException ex) {
            msg = "CONNECTION FAILED";
        }
    }

    public String getStr()
    {
        return msg;
    }
}
