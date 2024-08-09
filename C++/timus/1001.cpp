#include <bits/stdc++.h>

using namespace std;

int main(){
    vector<long long> V;
    long long a;
    while(scanf("%lld",&a)!=EOF){
        V.push_back(a);
    }
    for(int i=V.size()-1;i>=0;i--){
        printf("%.4lf\n",sqrt(V[i]));
    }
    return 0;
}
