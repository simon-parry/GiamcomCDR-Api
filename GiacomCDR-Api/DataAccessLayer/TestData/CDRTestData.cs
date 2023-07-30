namespace GiacomCDR_Api.DataAccessLayer.TestData
{
    public static class CDRTestData
    {
        public static Models.CallDetailRecord TestRecord1 = new()
        {
            Id = new Guid("6DCCECC1-A7DA-4A8E-9777-CF519415BDD5"),
            CallerId = "01214477497",
            Recipient = "07496934546",
            CallDate = DateTime.Now,
            EndTime = "14:21",
            Duration = 34,
            Cost = 0.34m,
            Reference = "12355"
        };

        public static Models.CallDetailRecord TestRecord2 = new()
        {
            Id = new Guid("9D2185F8-8608-406A-B4DB-9079039B1B27"),
            CallerId = "01214477497",
            Recipient = "07496934546",
            CallDate = DateTime.Now,
            EndTime = "16:28",
            Duration = 67,
            Cost = 0.54m,
            Reference = "12356"
        };

        public static Models.CallDetailRecord TestRecord3 = new()
        {
            Id = new Guid("0E0840DD-48AE-42B5-A2E2-5B8AC2FE9694"),
            CallerId = "01214477497",
            Recipient = "07496934546",
            CallDate = DateTime.Now,
            EndTime = "11:24",
            Duration = 180,
            Cost = 0.94m,
            Reference = "12357"
        };

        public static List<Models.CallDetailRecord> TestData = new() { TestRecord1, TestRecord2, TestRecord3 };
    }
}
