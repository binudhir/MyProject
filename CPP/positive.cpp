//Program to print positive number entered by theuser
//If the user enters a negativenumber, it skipped
#include<iostream>
using namespace std;
int main(){
    int number;
    cout<<"Enter an interger : ";
    cin>>number;
    // check if the number is positive
    if(number > 0){
        cout<<"You entered a Positive integer :"<< number << endl;
    }
    cout << "This Statement always Executed.";
    return 0;
}
