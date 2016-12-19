using BEL; //Iki Tekan Import Library BEL
using DataAccessLogic; //Iki Tekan Import Library DAL
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; //Iki Tekan Class e SQLClient
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class OPItem
    {

        public DBConnection db = new DBConnection(); //Tekan CTRL + . , Ben Iso Import
        public Item agg = new Item(); //Podo Koyo Instansiasi DBConnection

        //Jeneng Method e seterah
        public DataTable viewItem(Item i) //Data Table Iku Import disek + kudu duwe return
        {
            SqlCommand view = new SqlCommand(); //Iki kudu import pisan
            view.CommandType = CommandType.Text;
            view.CommandText = "SELECT * FROM dbo.Item";
            return db.ExeReader(view);
        }
        public int insertItem(Item a) //Iki kudu duwe return pisan
        {
            SqlCommand insert = new SqlCommand();
            insert.CommandType = CommandType.Text;
            insert.CommandText = "INSERT INTO dbo.Item VALUES('" + a.Name+ "','"+a.Desc+"')";
            return db.ExeNonQuery(insert);
        }

        public int deleteItem(Item cabe)
        {
            SqlCommand delete = new SqlCommand();
            delete.CommandType = CommandType.Text;
            delete.CommandText = "DELETE FROM dbo.Item where id = ('" + cabe.Id + "')";
            return db.ExeNonQuery(delete);
        }

        public int updateItem(Item aa)
        {
            SqlCommand upd = new SqlCommand();
            upd.CommandType = CommandType.Text;
            upd.CommandText = "UPDATE dbo.Item SET name='" + aa.Name + "',description='"+aa.Desc+"' where id = '" + aa.Id + "'";
            return db.ExeNonQuery(upd);
        }

    }
}
