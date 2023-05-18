#Prohram to print Hollow Rhombus Star Pattern
hrows=int(input("Enter the number :"))
print("Hollow Rhombus Star Pattern")
for i in range(hrows, 0, -1):
    for j in range(1, i):
        print(' ', end='')
    for k in range(0, hrows):
        if(i==1 or i==hrows or k==0 or k==hrows-1):
            print('*', end='')
        else:
            print(' ',end='')
    print()
