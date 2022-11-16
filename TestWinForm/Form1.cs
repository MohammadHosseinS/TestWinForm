using Entities;
namespace TestWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void FillGrid()
        {
            string connectionString = @"Persist Security Info=False;User ID=moghari2;password=123456;Initial Catalog=TestLike;Data Source=(local)";
            Bridge bridge = new Bridge(connectionString);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bridge.Read(idValue);
        }
        
        int? idValue = null;
        Bridge bridge = new Bridge(@"Persist Security Info=False;User ID=moghari2;password=123456;Initial Catalog=TestLike;Data Source=(local)");

        private async void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student() { name = textBox1.Text, family = textBox2.Text, codemelli = textBox3.Text };
            var res = await bridge.SaveStudents(student, idValue);
            MessageBox.Show(res.ToString());

            button1.Text = "Add Student";
            idValue = null;
            FillGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            button1.Text = "Update";
            idValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
            Student temp = idValue != null ? bridge.Read(idValue).FirstOrDefault() : new Student() { name = "null", family = "null", codemelli = "jadid sabt konid"} ;
            
            textBox1.Text = temp.name;
            textBox2.Text = temp.family;
            textBox3.Text = temp.codemelli;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}