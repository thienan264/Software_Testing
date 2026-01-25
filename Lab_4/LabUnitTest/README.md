# Tester_Tuan4 - Unit Test (NUnit)

Repo này chứa các bài thực hành Unit Test bằng C# + NUnit.

Cấu trúc project:

- `Tester_Tuan4/` : code các bài (Bai1.cs, Bai2.cs, ...)
- `Tester_Tuan4.Tests/` : unit test tương ứng (UnitTestBai1.cs, UnitTestBai2.cs, ...)
- `Tester_Tuan4.sln` : solution

## Yêu cầu

- Đã cài .NET SDK
- Kiểm tra bằng lệnh:

```bash
dotnet --version



Chạy toàn bộ test (Run All)

dotnet test

Chạy test riêng từng bài (Filter)
Bài 1
dotnet test --filter UnitTestBai1

Bài 2
dotnet test --filter UnitTestBai2

Bài 3
dotnet test --filter UnitTestBai3

Bài 4
dotnet test --filter UnitTestBai4

Bài 5
dotnet test --filter UnitTestBai5
