#define CMP_EQ(a, b) ((a) == (b))
#define CMP_LT(a, b) ((a) < (b))
#define CMP_GT(a, b) ((a) > (b))
#include<iostream>
#include<conio.h>
#include<ctime>
#include<locale.h>

using namespace std;

struct BinaryTree {
	int data;
	BinaryTree *left;
	BinaryTree *right;
	BinaryTree *parent;
	int height;
};
BinaryTree *BTree = NULL;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

BinaryTree *getFreeNode(int value, BinaryTree *parent)
{
	BinaryTree * tmp = new BinaryTree;
	tmp->left = tmp->right = NULL;
	tmp->data = value;
	tmp->parent = parent;
	return tmp;
}
//                                                                                      Search Binary TREE

void insert(BinaryTree **head, int value)
{
	BinaryTree *tmp = NULL;
	BinaryTree *ins = NULL;
	if (*head == NULL)
	{
		*head = getFreeNode(value, NULL);
		return;
	}
	tmp = *head;
	while (tmp)
	{
		if (CMP_GT(value, tmp->data))
		{
			if (tmp->right)
			{
				tmp = tmp->right;
				continue;
			}
			else {
				tmp->right = getFreeNode(value, tmp);
				return;
			}
		}
		else {
			if (CMP_LT(value, tmp->data))
			{
				if (tmp->left)
				{
					tmp = tmp->left;
					continue;
				}
				else
				{
					tmp->left = getFreeNode(value, tmp);
					return;
				}
			}
			else
			{
				exit(2);
			}
		}
	}
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


void  Make_Binary_Tree(BinaryTree **Node, int n)
{
	BinaryTree **ptr;
	srand(time(NULL) * 1000);
	while (n > 0)
	{
		ptr = Node;
		while (*ptr != NULL)
		{
			if ((double)rand() / RAND_MAX < 0.5)
			{
				ptr = &((*ptr)->left);
			}
			else
			{
				ptr = &((*ptr)->right);
			}
		}
		(*ptr) = new BinaryTree();
		cout << "Enter element: ";
		cin >> (*ptr)->data;
		n--;
	}
}


void Print_BinaryTree(BinaryTree *Node, int l)
{
	int i;
	if (Node != NULL)
	{
		Print_BinaryTree(Node->right, l + 1);
		for (i = 0; i < l; i++)
		{
			cout << "     ";
		}
		printf("%4d", Node->data);
		Print_BinaryTree(Node->left, l + 1);
	}
	else
	{
		cout << endl;
	}
}


void PreOrder_BinaryTree(BinaryTree *Node)
{
	if (Node != NULL)
	{
		printf("%3ld", Node->data);
		PreOrder_BinaryTree(Node->left);
		PreOrder_BinaryTree(Node->right);
	}
}


void PostOrder_BinaryTree(BinaryTree *Node)
{
	if (Node != NULL)
	{
		PostOrder_BinaryTree(Node->left);
		PostOrder_BinaryTree(Node->right);
		printf("%3ld", Node->data);
	}
}


void SymmetricOrder_BinaryTree(BinaryTree *Node)
{
	if (Node != NULL)
	{
		PostOrder_BinaryTree(Node->left);
		printf("%3ld", Node->data);
		PostOrder_BinaryTree(Node->right);
	}
}



void Insert_Node_BinaryTree(BinaryTree **Node, int Data)
{
	BinaryTree *New_Node = new BinaryTree;
	New_Node->data = Data;
	New_Node->left = NULL;
	New_Node->right = NULL;
	BinaryTree **ptr = Node;
	srand(time(NULL) * 1000);
	while (*ptr != NULL)
	{
		double q = (double)rand() / RAND_MAX;
		if (q < 1 / 3.0)
		{
			ptr = &((*ptr)->left);
		}
		else
		{
			if (q > 2 / 3.0)
			{
				ptr = &((*ptr)->right);
			}
			else
			{
				break;
			}
		}
	}
	if (*ptr != NULL)
	{
		if ((double)rand() / RAND_MAX < 0.5)
		{
			New_Node->left = *ptr;
		}
		else
		{
			New_Node->right = *ptr;
		}
		*ptr = New_Node;
	}
	else 
	{
		*ptr = New_Node;
	}
}


void Delete_Node_BinaryTree(BinaryTree **Node, int Data)
{
	if (*Node != NULL)
	{
		if ((*Node)->data == Data)
		{
			BinaryTree *ptr = (*Node);
			if ((*Node)->left == NULL && (*Node)->right == NULL)
			{
				*Node = NULL;
			}
			else
				if ((*Node)->left == NULL)
				{
					(*Node) = ptr->right;
				}
				else
					if ((*Node)->right == NULL)
					{
						(*Node) = ptr->left;
					}
					else
					{
						(*Node) = ptr->right;
						BinaryTree **ptr1;
						ptr1 = Node;
						while (*ptr1 != NULL)
						{
							ptr1 = &((*ptr1)->left);
						}
						(*ptr1) = ptr->left;
					}
					delete(ptr);
					Delete_Node_BinaryTree(Node, Data);
			}
		else
		{
			Delete_Node_BinaryTree(&((*Node)->left), Data);
			Delete_Node_BinaryTree(&((*Node)->right), Data);
		}
	}
}



bool Empty_BinaryTree(BinaryTree *Node)
{
	return (Node == NULL ? true : false);
}


 void Delete_BinatyTree(BinaryTree *Node)
{
	if (Node != NULL)
	{
		Delete_BinatyTree(Node->left);
		Delete_BinatyTree(Node->right);
		delete(Node);
	}
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
 BinaryTree *Add_Elem(BinaryTree *Node, int x)
{
	if (Node == NULL)
	{
		Node = new BinaryTree;
		Node->data = x;
		Node->left = NULL;
		Node->right = NULL;
	}
	else
	{
		if (x < Node->data)
		{
			Node->left = Add_Elem(Node->left, x);
		}
		else
		{
			Node->right = Add_Elem(Node->right, x);
		}
	}
	return Node;
}
 //                                                                                         TASK 2: Sort list with help Binary TREE

void output_tree(BinaryTree *Node)
{
	if (Node != NULL)
	{
		output_tree(Node->left);
		cout << Node->data << "  ";
		output_tree(Node->right);
	}
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
BinaryTree *PerfectTree(BinaryTree **Node, int n)
{
	BinaryTree *now;
	int x, nl, nr;
	now = *Node;
	if (n == 0)
	{
		*Node = NULL;
	}
	else
	{
		nl = n / 2;
		nr = n - nl - 1;
		cout << "Enter element: ";
		cin >> x;
		now = new BinaryTree;
		(*now).data = x;
		PerfectTree(&((*now).left), nl);
		PerfectTree(&((*now).right), nr);
		*Node = now;
	}
	return *Node;
}
//                                                                                          Perfect Balance Binary TREE
void Vyvod(BinaryTree **Node, int n)
{
	if (*Node != NULL)
	{
		Vyvod(&((**Node).right), n + 1);
		for (int i = 1; i <= n; i++)
		{
			cout << "    ";
		}
		cout << (**Node).data << endl;
		Vyvod(&((**Node).left), n + 1);
	}
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int max(int a, int b);

int Height(BinaryTree *N)
{
	if (N == NULL)
	{
		return 0;
	}
	return N->height;
}

int max(int a, int b)
{
	return (a > b) ? a : b;
}
//                                                                                AVL TREE
BinaryTree *newNode(int key)
{
	BinaryTree *node = new BinaryTree;
	node->data = key;
	node->left = NULL;
	node->right = NULL;
	node->height = 1;
	return (node);
}

BinaryTree *rightRotate(BinaryTree *y)
{
	BinaryTree *x = y->left;
	BinaryTree *T2 = x->right;
	
	x->right = y;
	y->left = T2;

	y->height = max(Height(y->left), Height(y->right)) + 1;
	x->height= max(Height(x->left), Height(x->right)) + 1;

	return x;
}

BinaryTree *leftRotate(BinaryTree *x)
{
	BinaryTree *y = x->right;
	BinaryTree *T2 = y->left;

	y->left = x;
	x->right = T2;

	x->height = max(Height(x->left), Height(x->right)) + 1;
	y->height = max(Height(y->left), Height(y->right)) + 1;

	return y;
}

int getBalance(BinaryTree *N)
{
	if (N == NULL)
	{
		return 0;
	}
	return Height(N->left) - Height(N->right);
}

BinaryTree *insert_avl(BinaryTree *node, int key)
{
	if (node == NULL)
	{
		return (newNode(key));
	}
	if (key < node->data)
	{
		node->left = insert_avl(node->left, key);
	}
	else
	{
		if (key > node->data)
		{
			node->right = insert_avl(node->right, key);
		}
		else
		{
			return node;
		}
	}

	node->height = 1 + max(Height(node->left), Height(node->right));

	int balance = getBalance(node);

	if (balance > 1 && key < node->left->data)
	{
		return rightRotate(node);
	}

	if (balance < -1 && key > node->right->data)
	{
		return leftRotate(node);
	}
	
	if (balance > 1 && key > node->left->data)
	{
		node->left = leftRotate(node->left);
		return rightRotate(node);
	}

	if (balance < 1 && key < node->right->data)
	{
		node->right = rightRotate(node->right);
		return leftRotate(node);
	}
	return node;
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
int main()
{
	int n,a;
	BinaryTree *Node = NULL;
	setlocale(LC_ALL, "rus");

	cout << "Enter size of binary tree: ";
	cin >> n;
	Node=PerfectTree(&Node, n);
	cout << "\n\t\t\t Идеально сбалансорованное бинарное дерево\n\n " << endl;
	Vyvod(&Node, n);
	/*cout << "\n\n\n";
	Delete_Node_BinaryTree(&Node, 2);
	Vyvod(&Node, n);*/
	
	cout << "\n\n\n\n\n";
	Node = NULL;
	insert(&Node, 31);
	insert(&Node, 45);
	insert(&Node, 21);
	insert(&Node, 7);
	insert(&Node, 11);
	insert(&Node, 32);
	insert(&Node, 40);
	insert(&Node, 63);
	cout << "\t\t\tБинарное дерево поиска \n\n" << endl;
	Vyvod(&Node, n);
	/*cout << "\n\n\n";
	Delete_Node_BinaryTree(&Node,7);
	Vyvod(&Node, n);*/
	
	cout << "\n\n\n\n\n";
	Node = NULL;
	Node = insert_avl(Node, 10);
	Node = insert_avl(Node, 20);
	Node = insert_avl(Node, 30);
	Node = insert_avl(Node, 45);
	Node = insert_avl(Node, 50);
	Node = insert_avl(Node, 25);
	cout << "\n\t\t\t AVL tree\n\n " << endl;
	Vyvod(&Node, n);
	/*cout << "\n\n\n";
	Delete_Node_BinaryTree(&Node,20);
	Vyvod(&Node, n);*/
	
	
	//---------------------------------------------------------TASK 2--------------------------------------------------
	 
	cout << "\n\n\n\n\n";
	Node = NULL;
	cout << "\t\t\tTask 2:\n";
	for (int i = 0; i < n; i++)
	{
		cout << "Enter element: ";
		cin >> a;
		Node = Add_Elem(Node, a);
	}
	cout << endl;
	output_tree(Node);
	_getch();
	return 0;
}