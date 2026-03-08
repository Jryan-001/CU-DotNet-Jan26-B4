namespace CollegeManagement
{
    public class Program
    {
        class CollageManagement
        {
            Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

            Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


            public int AddStudent(string studentId, string subject, int marks)
            {
                if (!studentRecords.ContainsKey(studentId))
                    studentRecords[studentId] = new Dictionary<string, int>();

                if (!subjectsRecords.ContainsKey(subject))
                    subjectsRecords[subject] = new Dictionary<string, int>();

                if (!subjectsStudentsOrder.ContainsKey(subject))
                    subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();

                if (!studentRecords[studentId].ContainsKey(subject))
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;

                    subjectsStudentsOrder[subject].AddLast(new KeyValuePair<string, int>(studentId, marks));
                }
                else
                {
                    if (marks > studentRecords[studentId][subject])
                    {
                        studentRecords[studentId][subject] = marks;
                        subjectsRecords[subject][studentId] = marks;

                        var node = subjectsStudentsOrder[subject].First;
                        while (node != null)
                        {
                            if (node.Value.Key == studentId)
                            {
                                node.Value = new KeyValuePair<string, int>(studentId, marks);
                                break;
                            }
                            node = node.Next;
                        }
                    }
                }

                return 1;
            }

            public int RemoveStudent(string studentId)
            {
                if (!studentRecords.ContainsKey(studentId))
                    return 0;

                foreach (var subject in studentRecords[studentId].Keys)
                {
                    if (subjectsRecords.ContainsKey(subject))
                        subjectsRecords[subject].Remove(studentId);

                    if (subjectsStudentsOrder.ContainsKey(subject))
                    {
                        var node = subjectsStudentsOrder[subject].First;
                        while (node != null)
                        {
                            if (node.Value.Key == studentId)
                            {
                                subjectsStudentsOrder[subject].Remove(node);
                                break;
                            }
                            node = node.Next;
                        }
                    }
                }

                studentRecords.Remove(studentId);
                return 1;
            }

            public string TopStudent(string subject)
            {
                if (!subjectsStudentsOrder.ContainsKey(subject))
                    return "";

                int max = subjectsStudentsOrder[subject].Max(x => x.Value);

                List<string> result = new List<string>();

                foreach (var s in subjectsStudentsOrder[subject])
                {
                    if (s.Value == max)
                        result.Add($"{s.Key} {s.Value}");
                }

                return string.Join("\n", result);
            }

            public string Result()
            {
                List<string> res = new List<string>();

                foreach (var student in studentRecords)
                {
                    double avg = student.Value.Values.Average();
                    res.Add($"{student.Key} {avg:F2}");
                }

                return string.Join("\n", res);
            }
        }

        public static void Main()
        {
            CollageManagement cm = new CollageManagement();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;

                string[] parts = input.Split();

                if (parts[0] == "ADD")
                {
                    cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
                }
                else if (parts[0] == "REMOVE")
                {
                    cm.RemoveStudent(parts[1]);
                }
                else if (parts[0] == "TOP")
                {
                    Console.WriteLine(cm.TopStudent(parts[1]));
                }
                else if (parts[0] == "RESULT")
                {
                    Console.WriteLine(cm.Result());
                }
            }
        }
    }
}
