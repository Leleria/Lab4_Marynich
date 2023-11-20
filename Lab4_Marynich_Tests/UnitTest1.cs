using Lab4_Marynich_Lib;
using NUnit.Framework;

namespace Lab4_Marynich_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveTestGetByID()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var temp = db.GetByID(5);

            var expect = "5" + "" + "Test" + "" + "Hello";
            var actual = "";

            foreach (var item in temp)
            {
                actual = item[0] + "" + item[1] + "" + item[2];
            }

            Assert.AreEqual(expect, actual);

            db.CloseConnection();
        }
        [Test]
        public void NegativeTestGetByID()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var temp = db.GetByID(145);

            var expect = "������ � ����� ID �� �������";
            var actual = "";

            foreach (var item in temp)
            {
                actual = item[0];
            }

            Assert.AreEqual(expect, actual);

            db.CloseConnection();
        }

        [Test]
        public void PositiveTestGetByName()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var temp = db.GetByName("Test");

            var expect = 5 + " " + "Test" + " " + "Hello";
            var actual = "";

            foreach (var item in temp)
            {
                actual = item[0] + " " + item[1] + " " + item[2];
            }

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

            
        }

        [Test]
        public void NegativeTestGetByName()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var temp = db.GetByName("Test1");

            var expect = "������ � ����� ������ �� �������";
            var actual = "";

            foreach (var item in temp)
            {
                actual = item[0];
            }

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

        }

        [Test]
        public void PositiveTestAddData()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var expect = "������ ��������� � ����";
            var actual = db.Add(1, "name", "message");

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

        }

        [Test]
        public void NegativeTestAddData()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var expect = "������ ������ ���� ���������";
            var actual = db.Add(6, null, null);

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

        }

        [Test]
        public void NegativeTestUpdate()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var expect = "������ � ����� ID �� �������";
            var actual = db.Update(158, "message");

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

        }

        [Test]
        public void PositiveTestUpdate()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var expect = "������ ������� ���������";
            var actual = db.Update(12, "message123");

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

        }

        [Test]
        public void NegativeTestDelete()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var expect = "������ � ����� ID �� �������";
            var actual = db.Delete(158);

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

        }

        [Test]
        public void PositiveTestDelete()
        {
            WorkerDB db = new WorkerDB();
            db.OpenConnection();

            var expect = "������ ������� �������";
            var actual = db.Delete(1);

            Assert.AreEqual(expect, actual);

            db.CloseConnection();

        }
    }
}