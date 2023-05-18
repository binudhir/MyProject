#Program to print Rhombus Star Pattern
rows=int(input("Enter the number :"))
print("Rhombus Star Pattern")
for i in range(rows, 0, -1):
    for j in range(1, i):
        print(' ', end='')
    for k in range(0, rows):
        print('*', end='')
    print()
