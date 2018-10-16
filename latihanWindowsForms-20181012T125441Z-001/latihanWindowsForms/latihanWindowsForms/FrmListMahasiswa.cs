using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace latihanWindowsForms
{
    public partial class FrmListMahasiswa : Form
    {
        public FrmListMahasiswa()
        {
            InitializeComponent();

            InitiasialisasiListView();
        }
        private void InitiasialisasiListView()
        {
            lvwMahasiswa.View = System.Windows.Forms.View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;
            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Npm", 70, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Nama", 180, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Jenis Kelamin", 80, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tempat Lahir", 75, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tgl. Lahir", 75, HorizontalAlignment.Left);
        }
        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!mskNpm.MaskFull)
            {
                MessageBox.Show("NPM harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskNpm.Focus();
                return;
            }
            if (!(txtNama.Text.Length > 0))
            {
                MessageBox.Show("Nama Harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var jeniskelamin = rdoLakiLaki.Checked ? "Laki-laki" : "Perempuan";

            var result = MessageBox.Show("Apakah data ingin disimpan?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mskNpm.Text);
                item.SubItems.Add(txtNama.Text);
                item.SubItems.Add(jeniskelamin);
                item.SubItems.Add(txtTempatLahir.Text);
                item.SubItems.Add(dtpTanggalLahir.Value.ToString("dd/MM/yyyy"));

                lvwMahasiswa.Items.Add(item);

                ResetForm();
           
            }
        }
        private void ResetForm()
        {
            mskNpm.Clear();
            txtNama.Clear();
            rdoLakiLaki.Checked = true;
            txtTempatLahir.Clear();
            dtpTanggalLahir.Value = DateTime.Today;

            mskNpm.Focus();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var index = lvwMahasiswa.SelectedIndices[0];

                var nama = lvwMahasiswa.Items[index].SubItems[2].Text;

                var msg = string.Format("Apakah data mahasiswa '{0}' ingin hapus ?", nama);

                var result = MessageBox.Show(msg, "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    lvwMahasiswa.Items[index].Remove();

                    for (var i = 0; i < lvwMahasiswa.Items.Count; i++)
                    {
                        // fungsi dari dari di bawah ini ketika nama mahasiswa di hapus akan mengurutkan pada semua nomer nya.
                        // caranya melakukan penghitungan jumlah item kemudian jumlah tersebut di lakukan perulangan untuk menghasilkan urutan.
                        var noUrut = i + 1;
                        lvwMahasiswa.Items[1].SubItems[0].Text = Convert.ToString(noUrut);
                    }
                }
            }
             else
            {
                MessageBox.Show("Data belum dipilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            var msg = "Apakah anda yakin ?";

            var result = MessageBox.Show(msg, "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
                this.Close();
        }
                    

        private void Double_Click(object sender, EventArgs e)
        {
            // fungsi double klik
            var index = lvwMahasiswa.SelectedIndices[0];
            var npm = lvwMahasiswa.Items[index].SubItems[1].Text;
            var name = lvwMahasiswa.Items[index].SubItems[2].Text;
            var jk = lvwMahasiswa.Items[index].SubItems[3].Text;
            var lahir = lvwMahasiswa.Items[index].SubItems[4].Text;
            var tanggal = lvwMahasiswa.Items[index].SubItems[5].Text;
            mskNpm.Text = npm;
            txtNama.Text = name;
            
            if (jk == "Laki-Laki")
            {
                rdoLakiLaki.Checked = true;
            }
            else if (jk == "Perempuan")
            {
                rdoPerempuan.Checked = true;
            }
            txtTempatLahir.Text = lahir;
            dtpTanggalLahir.Value = DateTime.Today;
        }
    }
}
