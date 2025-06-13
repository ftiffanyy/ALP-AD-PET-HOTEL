using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ALP_AD_PET_HOTEL
{
    public partial class PetKingdom : Form
    {
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        DataTable dthewan; DataTable dtpemilik; DataTable dtreservasi;
        DataTable dtfasilitas; DataTable dttransaksi; DataTable dtusefas;
        DataTable dtdata; DataTable dtnama;
        string query;
        string IDpemilik; string IDhewan; string fullname; string fullpet; int gender;
        int datecin; int datecout;
        string tglcin; string tglcout; string IDreservasi; string IDtransaksi;
        List<Panel> pdata = new List<Panel>();
        List<Label> lblnokamar = new List<Label>();
        List<Label> lbltanggal = new List<Label>();
        List<Label> lblstatus = new List<Label>();
        List<Label> lblname = new List<Label>();
        List<TextBox> tbbooking = new List<TextBox>();
        List<TextBox> tbhewan = new List<TextBox>();
        List<Button> btservice = new List<Button>();
        List<Button> btcout = new List<Button>();
        string reservid; //buat service
        string IDusefas; int totalakhir; int xtrans;


        public PetKingdom()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnect = new MySqlConnection("server =localhost;" + "uid =root;" + "pwd=Feli0102;" + "database=pethotel");
            p_homepage.Visible = true;
            p_isidata.Visible = false;
            p_booking.Visible = false;
            p_data.Visible = false;
            p_service1.Visible = false;
            p_service2.Visible = false;
            p_invoice.Visible = false;
            p_earnings.Visible = false;

            dthewan = new DataTable();
            query = "select * from hewan;";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dthewan);

            dtpemilik = new DataTable();
            query = "select * from pemilik;";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtpemilik);

            dtreservasi = new DataTable();
            query = "select * from reservasi_hotel;";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtreservasi);

            dttransaksi = new DataTable();
            query = "select * from transaksi;";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dttransaksi);

            dtusefas = new DataTable();
            query = "select * from use_fasilitas;";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtusefas);

            dtdata = new DataTable();
            dtdata.Columns.Add("Reservasi ID");
            dtdata.Columns.Add("Hewan ID");
            dtdata.Columns.Add("No Kamar");
            dtdata.Columns.Add("Check In Date");
            dtdata.Columns.Add("Check Out Date");
            dtdata.Columns.Add("Status");

            pdata.Add(p_data1); pdata.Add(p_data2); pdata.Add(p_data3); pdata.Add(p_data4); pdata.Add(p_data5); pdata.Add(p_data6);
            lblnokamar.Add(lbl_no1); lblnokamar.Add(lbl_no2); lblnokamar.Add(lbl_no3); lblnokamar.Add(lbl_no4); lblnokamar.Add(lbl_no5); lblnokamar.Add(lbl_no6);
            lbltanggal.Add(lbl_date1); lbltanggal.Add(lbl_date2); lbltanggal.Add(lbl_date3); lbltanggal.Add(lbl_date4); lbltanggal.Add(lbl_date5); lbltanggal.Add(lbl_date6);
            lblstatus.Add(lbl_status1); lblstatus.Add(lbl_status2); lblstatus.Add(lbl_status3); lblstatus.Add(lbl_status4); lblstatus.Add(lbl_status5); lblstatus.Add(lbl_status6);
            lblname.Add(lbl_name1); lblname.Add(lbl_name2); lblname.Add(lbl_name3); lblname.Add(lbl_name4); lblname.Add(lbl_name5); lblname.Add(lbl_name6);
            tbbooking.Add(tb_booking1); tbbooking.Add(tb_booking2); tbbooking.Add(tb_booking3); tbbooking.Add(tb_booking4); tbbooking.Add(tb_booking5); tbbooking.Add(tb_booking6);
            tbhewan.Add(tb_hewan1); tbhewan.Add(tb_hewan2); tbhewan.Add(tb_hewan3); tbhewan.Add(tb_hewan4); tbhewan.Add(tb_hewan5); tbhewan.Add(tb_hewan6);
            btservice.Add(bt_service1); btservice.Add(bt_service2); btservice.Add(bt_service3); btservice.Add(bt_service4); btservice.Add(bt_service5); btservice.Add(bt_service6);
            btcout.Add(bt_cout1); btcout.Add(bt_cout2); btcout.Add(bt_cout3); btcout.Add(bt_cout4); btcout.Add(bt_cout5); btcout.Add(bt_cout6);

            sqlConnect.Open();

        }

        private void bt_home_Click(object sender, EventArgs e)
        {
            p_homepage.Visible = true;
            p_isidata.Visible = false;
            p_booking.Visible = false;
            p_data.Visible = false;
            p_service1.Visible = false;
            p_service2.Visible = false;
            p_invoice.Visible = false;
            p_earnings.Visible = false;
        }

        private void bt_booking_Click(object sender, EventArgs e)
        {
            p_homepage.Visible = true;
            p_isidata.Visible = true;
            p_booking.Visible = false;
            p_data.Visible = false;
            p_service1.Visible = false;
            p_service2.Visible = false;
            p_invoice.Visible = false;
            p_earnings.Visible = false;
        }

        private void bt_savedata_Click(object sender, EventArgs e)
        {
            /*
            p_booking.Visible = true;
            p_data.Visible = false;
            p_service1.Visible = false;
            p_service2.Visible = false;

            bt_101.Visible = false;
            bt_102.Visible = false;
            bt_201.Visible = false;
            bt_202.Visible = false;
            bt_301.Visible = false;
            bt_302.Visible = false;
            */
            if (tb_fnameh.Text != "" && cb_typeh.Text != "" && tb_breedh.Text != "" && tb_ageh.Text != "" && tb_weighth.Text != "" && tb_fnamep.Text != "" && tb_phone.Text != "" && tb_email.Text != "" && tb_address.Text != "")
            {
                if(rb_female.Checked == false && rb_male.Checked == false)
                {
                    MessageBox.Show("ERROR");
                }
                else
                {
                    Save();
                    p_booking.Visible = true;
                    p_data.Visible = false;
                    p_service1.Visible = false;
                    p_service2.Visible = false;
                    p_invoice.Visible = false;
                    p_earnings.Visible = false;
                    bt_101.Visible = false;
                    bt_102.Visible = false;
                    bt_201.Visible = false;
                    bt_202.Visible = false;
                    bt_301.Visible = false;
                    bt_302.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            
        }

        private void tb_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tb_ageh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tb_weighth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void Save()
        {
            int id = dthewan.Rows.Count + 1;
            // ID PEMILIK
            int index = 0; bool yn = false;
            if (tb_lnamep.Text == "")
            {
                fullname = tb_fnamep.Text;
                for (int i = 0; i < dtpemilik.Rows.Count; i++)
                {
                    if (dtpemilik.Rows[i][0].ToString().Substring(0, 2).ToLower() == tb_fnamep.Text.Substring(0, 2).ToLower())
                    {
                        index = Convert.ToInt32(dtpemilik.Rows[i][0].ToString().Substring(2, 3));
                        index++;
                        yn = true; break;
                    }
                }
                if (yn == true)
                {
                    if (index < 10)
                    {
                        IDpemilik = tb_fnamep.Text.Substring(0, 2).ToUpper() + "00" + index;
                    }
                    if (10 <= index && index < 100)
                    {
                        IDpemilik = tb_fnamep.Text.Substring(0, 2).ToUpper() + "0" + index;
                    }
                    if (index >= 100)
                    {
                        IDpemilik = tb_fnamep.Text.Substring(0, 2).ToUpper() + index;
                    }
                }
                if (yn == false)
                {
                    IDpemilik = tb_fnamep.Text.Substring(0, 2).ToUpper() + "001";
                }
            }
            else if (tb_lnamep.Text != "")
            {
                string idnama = tb_fnamep.Text.Substring(0, 1) + tb_lnamep.Text.Substring(0, 1);
                fullname = tb_fnamep.Text + " " + tb_lnamep.Text;
                for (int i = 0; i < dtpemilik.Rows.Count; i++)
                {
                    if (dtpemilik.Rows[i][0].ToString().Substring(0, 2).ToLower() == idnama.ToLower())
                    {
                        index = Convert.ToInt32(dtpemilik.Rows[i][0].ToString().Substring(2, 3));
                        index++;
                        yn = true;
                    }
                }
                if (yn == true)
                {
                    if (index < 10)
                    {
                        IDpemilik = idnama.ToUpper() + "00" + index;
                    }
                    if (10 <= index && index < 100)
                    {
                        IDpemilik = idnama.ToUpper() + "0" + index;
                    }
                    if (index >= 100)
                    {
                        IDpemilik = idnama.ToUpper() + index;
                    }
                }
                if (yn == false)
                {
                    IDpemilik = idnama.ToUpper() + "001";
                }
            }
            // ID HEWAN
            if (tb_lnameh.Text == "")
            {
                fullpet = tb_fnameh.Text;
                if (id < 10)
                {
                    IDhewan = cb_typeh.Text.Substring(0, 1) + tb_fnameh.Text.Substring(0, 2).ToUpper() + "00" + id;
                }
                if (10 <= id && id < 100)
                {
                    IDhewan = cb_typeh.Text.Substring(0, 1) + tb_fnameh.Text.Substring(0, 2).ToUpper() + "0" + id;
                }
                if (id >= 100)
                {
                    IDhewan = cb_typeh.Text.Substring(0, 1) + tb_fnameh.Text.Substring(0, 2).ToUpper() + id;
                }
            }
            else if (tb_lnameh.Text != "")
            {
                fullpet = tb_fnameh.Text + " " + tb_lnameh.Text;
                if (id < 10)
                {
                    IDhewan = cb_typeh.Text.Substring(0, 1) + tb_fnameh.Text.Substring(0, 1).ToUpper() + tb_lnameh.Text.Substring(0, 1).ToUpper() + "00" + id;
                }
                if (10 <= id && id < 100)
                {
                    IDhewan = cb_typeh.Text.Substring(0, 1) + tb_fnameh.Text.Substring(0, 1).ToUpper() + tb_lnameh.Text.Substring(0, 1).ToUpper() + "0" + id;
                }
                if (id >= 100)
                {
                    IDhewan = cb_typeh.Text.Substring(0, 1) + tb_fnameh.Text.Substring(0, 1).ToUpper() + tb_lnameh.Text.Substring(0, 1).ToUpper() + id;
                }
            }
            // 0 = jantan, 1 = betina
            if (rb_male.Checked)
            {
                gender = 0;
            }
            if (rb_female.Checked)
            {
                gender = 1;
            }

            dtpemilik.Rows.Add(IDpemilik, fullname, tb_address.Text, tb_phone.Text, tb_email.Text, 0);
            dthewan.Rows.Add(IDhewan, IDpemilik, fullpet, cb_typeh.Text, tb_breedh.Text, tb_ageh.Text, gender, 0);

            // insert pemilik SQL
            try
            {
                query = $"insert into pemilik values ('{IDpemilik}', '{fullname}', '{tb_address.Text}', '{tb_phone.Text}', '{tb_email.Text}', 0);";
                sqlCommand = new MySqlCommand(query, sqlConnect);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // insert hewan SQL
            try
            {
                query = $"insert into hewan values ('{IDhewan}', '{IDpemilik}', '{fullpet}', '{cb_typeh.Text}', '{tb_breedh.Text}', '{tb_ageh.Text}', {gender}, 0);";
                sqlCommand = new MySqlCommand(query, sqlConnect);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // cek berat
            int kg = Convert.ToInt32(tb_weighth.Text);
            if (cb_typeh.Text == "Kelinci" || cb_typeh.Text == "Hamster" || cb_typeh.Text == "Guinea Pig" || cb_typeh.Text == "Landak" || cb_typeh.Text == "Iguana")
            {
                bt_201.Enabled = false; bt_202.Enabled = false;
                bt_301.Enabled = false; bt_302.Enabled = false;
            }
            if (2 < kg && kg < 10)
            {
                bt_101.Enabled = false; bt_102.Enabled = false;
            }
            if (kg > 10)
            {
                bt_101.Enabled = false; bt_102.Enabled = false;
                bt_201.Enabled = false; bt_202.Enabled = false;
            }
        }

        private void dtp_checkin_ValueChanged(object sender, EventArgs e)
        {
            tglcin = dtp_checkin.Value.ToString("yyyy") + dtp_checkin.Value.ToString("MM") + dtp_checkin.Value.ToString("dd");
            datecin = Convert.ToInt32(tglcin);
            if (dtp_checkout.Value > dtp_checkin.Value)
            {
                bt_101.Visible = true; bt_102.Visible = true;
                bt_201.Visible = true; bt_202.Visible = true;
                bt_301.Visible = true; bt_302.Visible = true;
                bt_101.Enabled = true; bt_102.Enabled = true;
                bt_201.Enabled = true; bt_202.Enabled = true;
                bt_301.Enabled = true; bt_302.Enabled = true;
                Data();
            }
            else
            {
                MessageBox.Show("Tanggal Check Out Lebih Kecil dari Tanggal Check In");
            }
        }


        private void dtp_checkout_ValueChanged(object sender, EventArgs e)
        {
            tglcout = dtp_checkout.Value.ToString("yyyy") + dtp_checkout.Value.ToString("MM") + dtp_checkout.Value.ToString("dd");
            datecout = Convert.ToInt32(tglcout);
            if (dtp_checkout.Value > dtp_checkin.Value)
            {
                bt_101.Visible = true; bt_102.Visible = true;
                bt_201.Visible = true; bt_202.Visible = true;
                bt_301.Visible = true; bt_302.Visible = true;
                bt_101.Enabled = true; bt_102.Enabled = true;
                bt_201.Enabled = true; bt_202.Enabled = true;
                bt_301.Enabled = true; bt_302.Enabled = true;
                Data();
            }
            else
            {
                MessageBox.Show("Tanggal Check Out Lebih Kecil dari Tanggal Check In");
            }
        }
        private void Data()
        {
            dtdata.Rows.Clear();
            for (int i = datecin; i < datecout; i++)
            {
                for (int j = 0; j < dtreservasi.Rows.Count; j++)
                {
                    string tanggal = dtreservasi.Rows[j][3].ToString().Substring(6, 4) + dtreservasi.Rows[j][3].ToString().Substring(3, 2) + dtreservasi.Rows[j][3].ToString().Substring(0, 2);
                    int tgl = Convert.ToInt32(tanggal);
                    string tanggal2 = dtreservasi.Rows[j][4].ToString().Substring(6, 4) + dtreservasi.Rows[j][4].ToString().Substring(3, 2) + dtreservasi.Rows[j][4].ToString().Substring(0, 2);
                    int tgl2 = Convert.ToInt32(tanggal2);
                    if (i == tgl)
                    {
                        dtdata.Rows.Add(dtreservasi.Rows[j][0], dtreservasi.Rows[j][1], dtreservasi.Rows[j][5], dtreservasi.Rows[j][3], dtreservasi.Rows[j][4], dtreservasi.Rows[j][7]);
                    }
                }
            }
            if (dtdata.Rows.Count != 0)
            {

                for (int i = 0; i < dtdata.Rows.Count; i++)
                {
                    if ("101" == dtdata.Rows[i][2].ToString())
                    {
                        bt_101.Enabled = false;
                    }
                    if ("102" == dtdata.Rows[i][2].ToString())
                    {
                        bt_102.Enabled = false;
                    }
                    if ("201" == dtdata.Rows[i][2].ToString())
                    {
                        bt_201.Enabled = false;
                    }
                    if ("202" == dtdata.Rows[i][2].ToString())
                    {
                        bt_202.Enabled = false;
                    }
                    if ("301" == dtdata.Rows[i][2].ToString())
                    {
                        bt_301.Enabled = false;
                    }
                    if ("302" == dtdata.Rows[i][2].ToString())
                    {
                        bt_302.Enabled = false;
                    }
                }
            }
        }

        private void bt_101_Click(object sender, EventArgs e)
        {
            tb_roomnob.Text = "101";
            tb_roomb.Text = "50000";
            TimeSpan diff = dtp_checkout.Value - dtp_checkin.Value;
            int total = diff.Days * 50000;
            tb_totalb.Text = "Rp. " + total.ToString("N");
        }

        private void bt_102_Click(object sender, EventArgs e)
        {
            tb_roomnob.Text = "102";
            tb_roomb.Text = "50000";
            TimeSpan diff = dtp_checkout.Value - dtp_checkin.Value;
            int total = diff.Days * 50000;
            tb_totalb.Text = "Rp. " + total.ToString("N");
        }

        private void bt_201_Click(object sender, EventArgs e)
        {
            tb_roomnob.Text = "201";
            tb_roomb.Text = "100000";
            TimeSpan diff = dtp_checkout.Value - dtp_checkin.Value;
            int total = diff.Days * 100000;
            tb_totalb.Text = "Rp. " + total.ToString();
        }

        private void bt_202_Click(object sender, EventArgs e)
        {
            tb_roomnob.Text = "202";
            tb_roomb.Text = "100000";
            TimeSpan diff = dtp_checkout.Value - dtp_checkin.Value;
            int total = diff.Days * 100000;
            tb_totalb.Text = "Rp. " + total.ToString("N");
        }

        private void bt_301_Click(object sender, EventArgs e)
        {
            tb_roomnob.Text = "301";
            tb_roomb.Text = "150000";
            TimeSpan diff = dtp_checkout.Value - dtp_checkin.Value;
            int total = diff.Days * 150000;
            tb_totalb.Text = "Rp. " + total.ToString("N");
        }

        private void bt_302_Click(object sender, EventArgs e)
        {
            tb_roomnob.Text = "302";
            tb_roomb.Text = "150000";
            TimeSpan diff = dtp_checkout.Value - dtp_checkin.Value;
            int total = diff.Days * 150000;
            tb_totalb.Text = "Rp. " + total.ToString("N");
        }

        private void bt_savebooking_Click(object sender, EventArgs e)
        {
            if (tb_roomb.Text != "")
            {
                string code = ""; int tigadigit = 0; bool yn = false;
                // ID RESERVASI
                if (tb_roomnob.Text.ToString().Substring(0, 1) == "1")
                {
                    code = "A" + tglcin.Substring(2, 6);
                }
                else if (tb_roomnob.Text.ToString().Substring(0, 1) == "2")
                {
                    code = "B" + tglcin.Substring(2, 6);
                }
                else if (tb_roomnob.Text.ToString().Substring(0, 1) == "3")
                {
                    code = "C" + tglcin.Substring(2, 6);
                }
                for (int i = 0; i < dtreservasi.Rows.Count; i++)
                {
                    if (code == dtreservasi.Rows[i][0].ToString().Substring(0, 7))
                    {
                        tigadigit = Convert.ToInt32(dtreservasi.Rows[i][0].ToString().Substring(7, 3)) + 1;
                        yn = true; 
                    }
                }
                if (yn)
                {
                    if (tigadigit < 10)
                    {
                        IDreservasi = code + "00" + tigadigit;
                    }
                    else if (10 < tigadigit && tigadigit < 100)
                    {
                        IDreservasi = code + "0" + tigadigit;
                    }
                    else if (tigadigit >= 100)
                    {
                        IDreservasi = code + tigadigit;
                    }
                }
                else if (yn == false)
                {
                    IDreservasi = code + "001";
                }

                dtreservasi.Rows.Add(IDreservasi, IDhewan, "", dtp_checkin.Value.ToString("yyyy-MM-dd"), dtp_checkout.Value.ToString("yyyy-MM-dd"), tb_roomnob.Text, tb_roomb.Text, "Check In", 0);
                query = $"insert into reservasi_hotel (reservasi_id, hewan_id, reservasi_tanggalawal, reservasi_tanggalakhir, reservasi_cage_no, reservasi_biaya_harian, reservasi_status, status_del) values ('{IDreservasi}', '{IDhewan}', '{dtp_checkin.Value.ToString("yyyy-MM-dd")}', '{dtp_checkout.Value.ToString("yyyy-MM-dd")}', '{tb_roomnob.Text}', {tb_roomb.Text}, 'Check In', 0);";
                sqlCommand = new MySqlCommand(query, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Reservation Completed");
                tb_fnameh.Text = ""; tb_lnameh.Text = ""; cb_typeh.Text = ""; tb_breedh.Text = ""; tb_ageh.Text = ""; rb_female.Checked = false; rb_male.Checked = false; tb_weighth.Text = "";
                tb_fnamep.Text = ""; tb_lnamep.Text = ""; tb_address.Text = ""; tb_phone.Text = ""; tb_email.Text = "";
                tb_roomnob.Text = ""; tb_roomb.Text = ""; tb_totalb.Text = "";
                p_homepage.Visible = true;
                p_isidata.Visible = false;
                p_booking.Visible = false;
            }
            else
            {
                MessageBox.Show("CHOOSE A ROOM");
            }
        }

        private void bt_data_Click(object sender, EventArgs e)
        {
            p_homepage.Visible = true;
            p_isidata.Visible = true;
            p_booking.Visible = true;
            p_data.Visible = true;
            p_service1.Visible = false;
            p_service2.Visible = false;
            p_invoice.Visible = false;
            p_earnings.Visible = false;
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            for (int i = 0; i < 6; i++)
            {
                btservice[i].Visible = false;
            }
            for (int i = 0; i < 6; i++)
            {
                btcout[i].Visible = false;
            }
        }

        private void dtp_data_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                btservice[i].Enabled = true;
            }
            for (int i = 0; i < 6; i++)
            {
                btcout[i].Enabled = true;
            }
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            string tgl = dtp_data.Value.ToString("yyyy") + dtp_data.Value.ToString("MM") + dtp_data.Value.ToString("dd");
            int date = Convert.ToInt32(tgl);
            Check(date);

            //buat service (hanya bisa input kalo checkin n occupied)
            for(int i = 0;i < 6; i++)
            {
                if (lblstatus[i].Text == "Check Out")
                {
                    btservice[i].Enabled = false;
                }
            }

            //buat availability (hanya bisa checkout kalo status occupied n checkout)
            for (int i = 0; i < 6; i++)
            {
                if (lblstatus[i].Text == "Check In")
                {
                    btcout[i].Enabled = false;
                }
            }
        }

        private void Check(int date)
        {
            dtdata.Rows.Clear();
            for (int i = 0; i < dtreservasi.Rows.Count; i++)
            {
                string tanggal = dtreservasi.Rows[i][3].ToString().Substring(6, 4) + dtreservasi.Rows[i][3].ToString().Substring(3, 2) + dtreservasi.Rows[i][3].ToString().Substring(0, 2);
                int datein = Convert.ToInt32(tanggal);
                string tanggal2 = dtreservasi.Rows[i][4].ToString().Substring(6, 4) + dtreservasi.Rows[i][4].ToString().Substring(3, 2) + dtreservasi.Rows[i][4].ToString().Substring(0, 2);
                int dateout = Convert.ToInt32(tanggal2);
                if (date == datein)
                {
                    string cin = dtreservasi.Rows[i][3].ToString().Substring(0, 10);
                    string cout = dtreservasi.Rows[i][4].ToString().Substring(0, 10);
                    dtdata.Rows.Add(dtreservasi.Rows[i][0], dtreservasi.Rows[i][1], dtreservasi.Rows[i][5], cin, cout, "Check In");
                }
                if (datein < date && date < dateout)
                {
                    string cin = dtreservasi.Rows[i][3].ToString().Substring(0, 10);
                    string cout = dtreservasi.Rows[i][4].ToString().Substring(0, 10);
                    dtdata.Rows.Add(dtreservasi.Rows[i][0], dtreservasi.Rows[i][1], dtreservasi.Rows[i][5], cin, cout, "Occupied");
                }
                if (date == dateout)
                {
                    string cin = dtreservasi.Rows[i][3].ToString().Substring(0, 10);
                    string cout = dtreservasi.Rows[i][4].ToString().Substring(0, 10);
                    dtdata.Rows.Add(dtreservasi.Rows[i][0], dtreservasi.Rows[i][1], dtreservasi.Rows[i][5], cin, cout, "Check Out");
                }
            }

            dtnama = new DataTable();
            for(int i = 0; i < dtdata.Rows.Count; i++)
            {
                query = $"select hewan_nama from hewan where hewan_id = '{dtdata.Rows[i][1].ToString()}';";
                sqlCommand = new MySqlCommand(query, sqlConnect);
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dtnama);

                pdata[i].Visible = true;
                lblnokamar[i].Text = dtdata.Rows[i][2].ToString();
                lbltanggal[i].Text = dtdata.Rows[i][3].ToString() + " - " + dtdata.Rows[i][4].ToString();
                lblstatus[i].Text = dtdata.Rows[i][5].ToString();
                tbbooking[i].Text = dtdata.Rows[i][0].ToString();
                tbhewan[i].Text = dtdata.Rows[i][1].ToString();
                lblname[i].Text = dtnama.Rows[i][0].ToString();
            }
        }

        private void bt_service_Click(object sender, EventArgs e)
        {
            p_homepage.Visible = true;
            p_isidata.Visible = true;
            p_booking.Visible = true;
            p_data.Visible = true;
            p_service1.Visible = false;
            p_service2.Visible = false;
            p_invoice.Visible = false;
            p_earnings.Visible = false;
            for (int i = 0; i < 6; i++)
            {
                btservice[i].Visible = true;
            }
            for (int i = 0; i < 6; i++)
            {
                btcout[i].Visible = false;
            }
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }

        }

        private void bt_service1_Click(object sender, EventArgs e)
        {
            reservid = tb_booking1.Text;
            p_service1.Visible = true;
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
        }

        private void bt_service2_Click(object sender, EventArgs e)
        {
            reservid = tb_booking2.Text;
            p_service1.Visible = true;
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
        }

        private void bt_service3_Click(object sender, EventArgs e)
        {
            reservid = tb_booking3.Text;
            p_service1.Visible = true;
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
        }

        private void bt_service4_Click(object sender, EventArgs e)
        {
            reservid = tb_booking4.Text;
            p_service1.Visible = true;
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
        }

        private void bt_service5_Click(object sender, EventArgs e)
        {
            reservid = tb_booking5.Text;
            p_service1.Visible = true;
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
        }

        private void bt_service6_Click(object sender, EventArgs e)
        {
            reservid = tb_booking6.Text;
            p_service1.Visible = true;
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
        }

        private void bt_availability_Click(object sender, EventArgs e)
        {
            p_homepage.Visible = true;
            p_isidata.Visible = true;
            p_booking.Visible = true;
            p_data.Visible = true;
            p_service1.Visible = true;
            p_service2.Visible = true;
            p_invoice.Visible = true;
            p_earnings.Visible = true;
            for (int i = 0; i < 6; i++)
            {
                btservice[i].Visible = false;
            }
            for (int i = 0; i < 6; i++)
            {
                btcout[i].Visible = true;
            }
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
        }

        private void bt_cout1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service1.Visible = true;
            p_service2.Visible = true;
            p_invoice.Visible = true;
            p_earnings.Visible = false;
            Invoice(0, lbl_name1.Text, lbl_no1.Text);
        }

        private void bt_cout2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service1.Visible = true;
            p_service2.Visible = true;
            p_invoice.Visible = true;
            p_earnings.Visible = false;
            Invoice(1, lbl_name2.Text, lbl_no2.Text);
        }

        private void bt_cout3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service1.Visible = true;
            p_service2.Visible = true;
            p_invoice.Visible = true;
            p_earnings.Visible = false;
            Invoice(2, lbl_name3.Text, lbl_no3.Text);
        }

        private void bt_cout4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service1.Visible = true;
            p_service2.Visible = true;
            p_invoice.Visible = true;
            p_earnings.Visible = false;
            Invoice(3, lbl_name4.Text, lbl_no4.Text);
        }

        private void bt_cout5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service1.Visible = true;
            p_service2.Visible = true;
            p_invoice.Visible = true;
            p_earnings.Visible = false;
            Invoice(4, lbl_name5.Text, lbl_no5.Text);
        }

        private void bt_cout6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service1.Visible = true;
            p_service2.Visible = true;
            p_invoice.Visible = true;
            p_earnings.Visible = false;
            Invoice(5, lbl_name6.Text, lbl_no6.Text);
        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service2.Visible = true;
        }

        private void bt_obat_Click(object sender, EventArgs e)
        {
            Usefas("F01", 5000);
        }

        private void bt_playground_Click(object sender, EventArgs e)
        {
            Usefas("F02", 50000);
        }

        private void bt_jemur_Click(object sender, EventArgs e)
        {
            Usefas("F03", 20000);
        }

        private void bt_grooming_Click(object sender, EventArgs e)
        {
            Usefas("F04", 100000);
        }

        private void bt_fnb_Click(object sender, EventArgs e)
        {
            Usefas("F05", 50000);

        }

        private void bt_darurat_Click(object sender, EventArgs e)
        {
            Usefas("F07", 100000);
        }

        private void bt_pelatihan_Click(object sender, EventArgs e)
        {
            Usefas("F11", 200000);
        }

        private void bt_pemeriksaan_Click(object sender, EventArgs e)
        {
            Usefas("F12", 200000);
        }

        private void bt_foto_Click(object sender, EventArgs e)
        {
            Usefas("F13", 100000);
        }

        private void bt_ultah_Click(object sender, EventArgs e)
        {
            Usefas("F15", 200000);
        }

        private void bt_mainan_Click(object sender, EventArgs e)
        {
            Usefas("F18", 20000);
        }

        private void bt_film_Click(object sender, EventArgs e)
        {
            Usefas("F20", 50000);
        }

        private void bt_pengawasan_Click(object sender, EventArgs e)
        {
            Usefas("F06", 0);
        }

        private void bt_pembersihan_Click(object sender, EventArgs e)
        {
            Usefas("F08", 0);
        }

        private void bt_suhu_Click(object sender, EventArgs e)
        {
            Usefas("F09", 0);
        }

        private void bt_pengasuhan_Click(object sender, EventArgs e)
        {
            Usefas("F14", 0);
        }

        private void bt_renang_Click(object sender, EventArgs e)
        {
            Usefas("F17", 0);
        }

        private void bt_cctv_Click(object sender, EventArgs e)
        {
            Usefas("F19", 0);
        }

        private void bt_transpotasi_Click(object sender, EventArgs e)
        {
            // F10 (HARGA GTW) ada textbox alamat
            Usefas("F10", 50000);
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdata.Rows.Count; i++)
            {
                pdata[i].Visible = false;
            }
            p_service2.Visible = false;
            p_service1.Visible = true;
        }
        private void Usefas(string kodefas, int fasprice)
        {
            // Kode Usefas
            int index = 0; 
            for (int i = 0; i < dtusefas.Rows.Count; i++)
            {
                if (dtusefas.Rows[i][0].ToString().Substring(0, 3) == kodefas)
                {
                    index = Convert.ToInt32(dtusefas.Rows[i][0].ToString().Substring(3)) + 1;
                }
            }
            if (index != 0)
            {
                if(index < 10)
                {
                    IDusefas = kodefas + "00" + index;
                }
                else if(10 < index && index < 100)
                {
                    IDusefas = kodefas + "0" + index;
                }
                else if(index > 100)
                {
                    IDusefas = kodefas + index;
                }
            }
            else
            {
                IDusefas = kodefas + "001";
            }
            string tglusefas = dtp_data.Value.ToString("yyyy") + "-" + dtp_data.Value.ToString("MM") + "-" + dtp_data.Value.ToString("dd");
            dtusefas.Rows.Add(IDusefas, tglusefas, reservid, kodefas, fasprice);
            query = $"insert into use_fasilitas values ('{IDusefas}', '{tglusefas}', '{reservid}', '{kodefas}', {fasprice}, 0);";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Service Added");
            p_service1.Visible = false; 
            p_service2.Visible = false;
        }
        private void Invoice(int x, string nama, string kamar)
        {
            bt_checkout.Enabled = false;
            xtrans = x;
            dtp_cin.Value = Convert.ToDateTime(dtdata.Rows[x][3]);
            dtp_cout.Value = dtp_data.Value;
            TimeSpan diff = dtp_cout.Value - dtp_cin.Value;
            tb_days.Text = diff.Days.ToString();
            tb_petname.Text = nama;
            tb_kamar.Text = kamar;

            dtfasilitas = new DataTable();
            query = $"select u.reservasi_id, f.fasilitas_nama, sum(u.usefas_biaya) from use_fasilitas u join fasilitas f on u.fasilitas_id = f.fasilitas_id where u.reservasi_id = '{dtdata.Rows[x][0].ToString()}' group by 2;";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtfasilitas);
            string fasilitas = "";
            for(int i = 0; i < dtfasilitas.Rows.Count; i++)
            {
                fasilitas += "- " + dtfasilitas.Rows[i][1].ToString();
                fasilitas += Environment.NewLine;
            }
            lbl_fas.Text = fasilitas;

            DataTable dtidcust = new DataTable();
            query = $"select pemilik_code from hewan where hewan_id = '{dtdata.Rows[x][1].ToString()}';";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtidcust);
            tb_idcust.Text = dtidcust.Rows[0][0].ToString();
            int hargakmr = 0;
            if(kamar.Substring(0,1) == "1")
            {
                hargakmr = Convert.ToInt32(diff.Days) * 50000;
            }
            if (kamar.Substring(0, 1) == "2")
            {
                hargakmr = Convert.ToInt32(diff.Days) * 100000;
            }
            if (kamar.Substring(0, 1) == "3")
            {
                hargakmr = Convert.ToInt32(diff.Days) * 150000;
            }
            tb_bookprice.Text = "Rp. " + hargakmr.ToString("N");

            int hargafas = 0;
            for(int i = 0; i < dtfasilitas.Rows.Count; i++)
            {
                hargafas += Convert.ToInt32(dtfasilitas.Rows[i][2]);
            }
            tb_fasprice.Text = "Rp. " + hargafas.ToString("N");

            totalakhir = hargakmr + hargafas;
            lbl_total.Text = "Rp. " + totalakhir.ToString("N");
            

            // ID TRANSAKSI (tgl cout)
            string tcode = dtp_cout.Value.ToString("yy") + dtp_cout.Value.ToString("MM") + dtp_cout.Value.ToString("dd"); int takhir = 0; bool tf = false;
            for (int i = 0; i < dtreservasi.Rows.Count; i++)
            {
                if(dtreservasi.Rows[i][2].ToString().Length == 0)
                {

                }
                else
                {
                    if (tcode == dtreservasi.Rows[i][2].ToString().Substring(0, 6))
                    {
                        takhir = Convert.ToInt32(dtreservasi.Rows[i][2].ToString().Substring(6, 4)) + 1;
                        tf = true; break;
                    }
                }
            }
            if (tf)
            {
                if (takhir < 10)
                {
                    IDtransaksi = tcode + "000" + takhir;
                }
                else if (10 < takhir && takhir < 100)
                {
                    IDtransaksi = tcode + "00" + takhir;
                }
                else if (100 < takhir && takhir < 1000)
                {
                    IDtransaksi = tcode + "0" + takhir;
                }
                else if (takhir >= 1000)
                {
                    IDtransaksi = tcode + takhir;
                }
            }
            else if (tf == false)
            {
                IDtransaksi = tcode + "0001";
            }
        }

        private void bt_checkout_Click(object sender, EventArgs e)
        {
            string tgltrans = dtp_cout.Value.ToString("yyyy-MM-dd"); int xreservasi = 0;
            for (int i = 0; i < dtreservasi.Rows.Count; i++)
            {
                if (dtdata.Rows[xtrans][0].ToString() == dtreservasi.Rows[i][0].ToString())
                {
                    xreservasi = i; break;
                }
            }
            if (dtreservasi.Rows[xreservasi][2].ToString() != "")
            {
                MessageBox.Show("Already Paid");
                p_invoice.Visible = false;
                p_service1.Visible = false;
                p_service2.Visible = false;
            }
            else
            {
                query = $"insert into transaksi values ('{IDtransaksi}', '{tb_idcust.Text}', '{tgltrans}', {totalakhir}, '{cb_method.Text}', 'Paid', 0);";
                sqlCommand = new MySqlCommand(query, sqlConnect);
                sqlCommand.ExecuteNonQuery();

                if (tgltrans == dtdata.Rows[xtrans][4].ToString())
                {
                    query = $"update reservasi_hotel set transaksi_id = '{IDtransaksi}', reservasi_status = 'Check Out' where reservasi_id = '{dtdata.Rows[xtrans][0].ToString()}';";
                    sqlCommand = new MySqlCommand(query, sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    dtreservasi.Rows[xreservasi][2] = IDtransaksi;
                    dtreservasi.Rows[xreservasi][7] = "Check Out";
                    MessageBox.Show("Payment Received");
                }
                else
                {
                    query = $"update reservasi_hotel set transaksi_id = '{IDtransaksi}', reservasi_tanggalakhir = '{tgltrans}', reservasi_status = 'Check Out' where reservasi_id = '{dtdata.Rows[xtrans][0].ToString()}';";
                    sqlCommand = new MySqlCommand(query, sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    dtreservasi.Rows[xreservasi][2] = IDtransaksi;
                    dtreservasi.Rows[xreservasi][4] = tgltrans;
                    dtreservasi.Rows[xreservasi][7] = "Check Out";
                    MessageBox.Show("Payment Received");
                    p_earnings.Visible = true;
                }
            }
        }

        private void cb_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_method.Text != "")
            {
                bt_checkout.Enabled = true;
            }
            else
            {
                bt_checkout.Enabled = false;
            }
        }

        private void bt_coutreport_Click(object sender, EventArgs e)
        {
            p_homepage.Visible = true;
            p_isidata.Visible = true;
            p_booking.Visible = true;
            p_data.Visible = true;
            p_service1.Visible = false;
            p_service2.Visible = false;
            p_invoice.Visible = false;
            p_earnings.Visible = false;
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            DataTable dtail = new DataTable();
            DataTable earn = new DataTable();
            string tanggal = date.Value.ToString("yyyy-MM-dd");
            query = "SELECT pemilik.pemilik_nama AS 'Owner Name',hewan.hewan_nama AS 'Pet Name'," +
                "CONCAT('Rp.', FORMAT((DATEDIFF(reservasi_hotel.reservasi_tanggalakhir, " +
                "reservasi_hotel.reservasi_tanggalawal) * reservasi_hotel.reservasi_biaya_harian), 0)) AS 'Room Cost'," +
                "CONCAT('Rp.', FORMAT(SUM(use_fasilitas.usefas_biaya), 0)) AS 'Facility Cost', " +
                "CONCAT('Rp.', FORMAT(((DATEDIFF(reservasi_hotel.reservasi_tanggalakhir, reservasi_hotel.reservasi_tanggalawal) * reservasi_hotel.reservasi_biaya_harian) + " +
                "SUM(use_fasilitas.usefas_biaya)), 0)) AS 'Total'" +
                "FROM pemilik LEFT JOIN hewan ON hewan.pemilik_code = pemilik.pemilik_code " +
                "LEFT JOIN reservasi_hotel ON reservasi_hotel.hewan_id = hewan.hewan_id " +
                "LEFT JOIN use_fasilitas ON use_fasilitas.reservasi_id = reservasi_hotel.reservasi_id " +
                "WHERE reservasi_hotel.reservasi_tanggalakhir = '" + tanggal + "' AND reservasi_hotel.reservasi_status = 'Check Out' AND reservasi_hotel.transaksi_id is not null " +
                "GROUP BY pemilik.pemilik_nama,hewan.hewan_nama,reservasi_hotel.reservasi_tanggalawal,reservasi_hotel.reservasi_tanggalakhir," +
                "reservasi_hotel.reservasi_biaya_harian;";
            sqlCommand = new MySqlCommand(query, sqlConnect);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dtail);
            dgv.DataSource = dtail;
            if (dtail.Rows.Count > 0)
            {
                query = "select concat('Rp. ',format(sum(`Biaya Reservasi`),0)) as `r`,concat('Rp. ',format(sum(`Biaya Fasilitas`),0)) as `f` ," +
                    "concat('Rp. ',format(sum(`Biaya Reservasi`+`Biaya Fasilitas`),0)) as total " +
                    "from(SELECT pemilik.pemilik_nama AS 'Nama Pemilik',hewan.hewan_nama AS 'Nama Hewan'," +
                    "DATEDIFF(reservasi_hotel.reservasi_tanggalakhir, reservasi_hotel.reservasi_tanggalawal) * reservasi_hotel.reservasi_biaya_harian AS `Biaya Reservasi`," +
                    "SUM(use_fasilitas.usefas_biaya) AS `Biaya Fasilitas`, " +
                    "((DATEDIFF(reservasi_hotel.reservasi_tanggalakhir, reservasi_hotel.reservasi_tanggalawal) * reservasi_hotel.reservasi_biaya_harian) + " +
                    "SUM(use_fasilitas.usefas_biaya)) AS 'Total'" +
                    "FROM pemilik LEFT JOIN hewan ON hewan.pemilik_code = pemilik.pemilik_code " +
                    "LEFT JOIN reservasi_hotel ON reservasi_hotel.hewan_id = hewan.hewan_id " +
                    "LEFT JOIN use_fasilitas ON use_fasilitas.reservasi_id = reservasi_hotel.reservasi_id " +
                    "WHERE reservasi_hotel.reservasi_tanggalakhir = '" + tanggal + "' AND reservasi_hotel.reservasi_status = 'Check Out' AND reservasi_hotel.transaksi_id is not null " +
                    "GROUP BY pemilik.pemilik_nama,hewan.hewan_nama,reservasi_hotel.reservasi_tanggalawal,reservasi_hotel.reservasi_tanggalakhir," +
                    "reservasi_hotel.reservasi_biaya_harian) as a";
                sqlCommand = new MySqlCommand(query, sqlConnect);
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(earn);
                lbl_totalreport.Text = earn.Rows[0][2].ToString();
                lbl_facilityreport.Text = earn.Rows[0][1].ToString();
                lbl_roomreport.Text = earn.Rows[0][0].ToString();
            }
            else
            {
                lbl_totalreport.Text = "Rp. 0";
                lbl_facilityreport.Text = "Rp. 0";
                lbl_roomreport.Text = "Rp. 0";
            }
        }
    }
}
