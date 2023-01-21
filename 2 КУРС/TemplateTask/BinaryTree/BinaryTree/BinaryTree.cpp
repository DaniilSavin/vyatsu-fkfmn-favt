#include <iostream>
#include <vector>
#include <string>
#include <iomanip>
#include <functional>

using namespace std;

template <typename T>
class binaryTree
{
private:
	typedef struct nodeTree
	{
		nodeTree* leftChild = NULL;
		nodeTree* rightChild = NULL;
		T value;
		nodeTree(T);
	};

	nodeTree* root = NULL;
	void del(nodeTree&);
	void _push(nodeTree&, nodeTree&);
	bool _search(int, nodeTree*);
	string _Leaves(nodeTree* current, string& res);

public:
	binaryTree();
	~binaryTree();
	void push(T);
	void print();
	void _print(nodeTree* p, int indent);
	string leaves();
	bool search(T);
	bool pop(T value);
};

template <typename T>
binaryTree<T>::nodeTree::nodeTree(T value) :value(value) {}

template <typename T>
binaryTree<T>::binaryTree() {}
template<typename T>
binaryTree<T>::~binaryTree()
{
	if (root != NULL)
		del(*root);
};

template <typename T>
void binaryTree<T>::del(nodeTree& cur)
{
	if (&cur == NULL)
		return;
	if (cur.rightChild != NULL)
		del(*cur.rightChild);
	if (cur.leftChild != NULL)
		del(*cur.leftChild);
	delete& cur;
}

template <typename T>
void binaryTree<T>::print()
{
	if (root != NULL)
	{
		_print(root, 0);
	}
}
template <typename T>
void binaryTree<T>::_print(nodeTree* p, int indent)
{
	if (p != NULL)
	{
		if (p->rightChild)
		{
			_print(p->rightChild, indent + 4);
		}
		if (indent)
		{
			cout << setw(indent) << ' ';
		}
		if (p->rightChild) 
			cout << " /\n" << setw(indent) << ' ';
		cout << p->value << "\n ";
		if (p->leftChild)
		{
			cout << setw(indent) << ' ' << " \\\n";
			_print(p->leftChild, indent + 4);
		}
	}
}
template<typename T>
void binaryTree<T>::_push(nodeTree& current, nodeTree& temp)
{
	if (temp.value > current.value)
	{
		if (current.rightChild != NULL)
			_push(*current.rightChild, temp);
		else
			current.rightChild = &temp;
	}
	else
	{
		if (current.leftChild != NULL)
			_push(*current.leftChild, temp);
		else
			current.leftChild = &temp;
	}
}

template <typename T>
void binaryTree<T>::push(T value)
{
	nodeTree* temp = new nodeTree(value);
	if (root == NULL)
		root = temp;
	else if (!search(value))
		_push(*root, *temp);
}

template <typename T>
bool binaryTree<T>::search(T value)
{
	if (root == NULL)
		return false;
	else
		return _search(value, root);
}

template<typename T>
bool binaryTree<T>::_search(int value, nodeTree* current)
{
	if (value == current->value)
		return true;
	if (current->leftChild != NULL && value < current->value)
		return _search(value, current->leftChild);
	if (current->rightChild != NULL && value >= current->value)
		return _search(value, current->rightChild);
	return false;
}

template <typename T>
string binaryTree<T>::leaves()
{
	string res = "";
	if (root)
		_Leaves(root, res);
	return res;
}

template <typename T>
string binaryTree<T>::_Leaves(nodeTree* current, string& res)
{
	if (current->leftChild)
		_Leaves(current->leftChild, res);
	if (current->rightChild != NULL)
		_Leaves(current->rightChild, res);
	if (current->leftChild == NULL && current->rightChild == NULL)
		cout << current->value << ' ';
	return res;
}

template <typename T>
bool binaryTree<T>::pop(T value)
{
	function<nodeTree* (nodeTree*, int)> helper = [&helper](nodeTree* current, int value) -> nodeTree*
	{
		if (!current)
			return current;
		else if (value < current->value)
		{
			current->leftChild = helper(current->leftChild, value);
			return current;
		}
		else if (value > current->value)
		{
			current->rightChild = helper(current->rightChild, value);
			return current;
		}
		else
		{
			if (!current->leftChild)
			{
				nodeTree* temp = current->rightChild;
				delete current;
				return temp;
			}
			else if (!current->rightChild)
			{
				nodeTree* temp = current->leftChild;
				delete current;
				return temp;
			}
			else
			{
				function<nodeTree* (nodeTree*)> find_max = [](nodeTree* current) -> nodeTree*
				{
					while (current->rightChild)
						current = current->rightChild;
					return current;
				};
				nodeTree* max_nodeTree = find_max(current->leftChild);
				current->value = max_nodeTree->value;
				current->leftChild = helper(current->leftChild, max_nodeTree->value);
				return current;
			}
		}
	};
	if (!search(value))
		return false;
	helper(root, value);
	return true;
}

int main()
{
	binaryTree<int> BinTree;
	BinTree.push(3);
	BinTree.push(4);
	BinTree.push(5);
	BinTree.push(2);
	BinTree.push(7);
	BinTree.push(8);
	BinTree.push(12);
	cout << "Output Tree: " << endl;
	BinTree.print();
	if (BinTree.search(8))
	{
		BinTree.pop(8);
	}
	else
	{
		cout << "Not Found" << endl;
	}
	cout << "\nOutput after removing: " << endl;
	BinTree.print();
	cout << "\nOutput leaves: " << endl;
	BinTree.leaves();
}