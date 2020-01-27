#include <iostream>
#include <vector>

int main(int argc, char const *argv[])
{
    std::vector<int> vec(50);

    std::cout << "size:" << vec.size() << " capacity:" << vec.capacity() << std::endl;

    vec.push_back(2);

    std::cout << "size:" << vec.size() << " capacity:" << vec.capacity() << std::endl;

    vec.reserve(120);

    std::cout << "size:" << vec.size() << " capacity:" << vec.capacity() << std::endl;

    vec.push_back(2);

    std::cout << "size:" << vec.size() << " capacity:" << vec.capacity() << std::endl;


    return 0;
}

