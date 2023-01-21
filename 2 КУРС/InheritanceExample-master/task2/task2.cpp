// task2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>

using namespace std; 

class ComputerGameObject
{
private:
    string Name;
protected:
    ComputerGameObject(const string& _Name) : Name(_Name){}
    ComputerGameObject(const ComputerGameObject& obj) : Name(obj.Name) {}
    virtual ~ComputerGameObject() { cout<< "ComputerGameObject deleted" << endl; }
    virtual void _print() const
    {
        cout << "\nName: " << Name << endl; 
    }
public:
    virtual void draw() = 0;
    void print() const
    {
        cout << endl << typeid(*this).name() << ": ";
        _print();
        
    }
};


class Creature : public ComputerGameObject
{
private:
    int healthPoints;
    int strength;
    int agility;
    int endurance;
    int dX;
    int dY;

public:
    Creature(const string& _Name, int _healthPoints, int _strength, int _agility, int _endurance): 
        ComputerGameObject(_Name), healthPoints(_healthPoints), strength(_strength), agility(_agility), endurance(_endurance), dX(0), dY(0) {}
    Creature(const Creature& obj) :
        ComputerGameObject(obj), healthPoints(obj.healthPoints), strength(obj.strength), agility(obj.agility), endurance(obj.endurance), dX(obj.dX), dY(obj.dY) {}
    Creature(const string& _Name, int _healthPoints, int _strength, int _agility, int _endurance, int _dX, int _dY): 
        ComputerGameObject(_Name), healthPoints(_healthPoints), strength(_strength), agility(_agility), endurance(_endurance), dX(_dX), dY(_dY) {}
    void _move(int X, int Y)
    {
        dX = X;
        dY = Y;
    }
    int getX()
    {
        return dX;
    }
    int getY()
    {
        return dY;
    }
    ~Creature() {}
protected:
    virtual void move(int, int) = 0;
    void  _print()const override
    {
        ComputerGameObject::_print();
        
        cout << "Количество здоровья: " << healthPoints << "\nСила: " << strength << "\nЛовкость: " << agility << "\nВыносливость: " << endurance << "\nX: " << dX << " Y: " << dY << endl;
    }
};

class mythicalAnimal : public Creature
{
private:
    bool mythicalStrenght;
public:
    mythicalAnimal(const string& _Name, int _healthPoints, int _strenght, int _agility, int _endurance, bool _mythicalStrenght):
        Creature(_Name, _healthPoints, _strenght, _agility, _endurance), mythicalStrenght(_mythicalStrenght) {}
    mythicalAnimal(const mythicalAnimal& obj) : Creature(obj), mythicalStrenght(obj.mythicalStrenght) {}
    mythicalAnimal(const string& _Name, int _healthPoints, int _strenght, int _agility, int _endurance, bool _mythicalStrenght, int _dX, int _dY) :
        Creature(_Name, _healthPoints, _strenght, _agility, _endurance, _dX, _dY), mythicalStrenght(_mythicalStrenght) {}
    ~mythicalAnimal() {}
    void move(int X, int Y) override {
        Creature::_move(X, Y);
        cout << "______________________________________________________________" << endl;
       cout << "Мифическое животное переместилось в: (" << getX() << ";" << getY() << ")" << endl;
    }
    void draw()
    {
        cout << "Местоположение мифического животного: (" << getX() << ";" << getY() << ")" << endl;
    }
protected:
    void _print() const override
    {
        Creature::_print();
        cout << "Магическая сила: " << mythicalStrenght << endl;
    }
};


class human : public Creature
{
private:
    int level;
    int luck;
public:
    human(const string& _Name, int _healthPoints, int _strenght, int _agility, int _endurance, int _level, int _luck) :Creature(_Name, _healthPoints, _strenght, _agility, _endurance), level(_level), luck(_luck) {}
    human(const human& obj) : Creature(obj), level(obj.level), luck(obj.luck) {}
    human(const string& _Name, int _healthPoints, int _strenght, int _agility, int _endurance, int _level, int _luck, int _dX, int _dY) :
        Creature(_Name, _healthPoints, _strenght, _agility, _endurance, _dX, _dY), level(_level), luck(_luck) {}
    ~human() {}
    void move(int X, int Y) override {
        Creature::_move(X, Y);
        cout << "______________________________________________________________" << endl;
        cout << "\nЧеловекоподобный персонаж переместился в: (" << getX() << ";" << getY() << ")" << endl;
    }
    void draw() override
    {
        cout << "Местоположение человекоподобного персонажа: (" << getX() << ";" << getY() << ")" << endl;
    }
protected:
    void _print() const override
    {
        Creature::_print();
        cout << "Уровень: " << level << endl << "Удача: " << luck << endl;
    }
};

class magicCharacter : public Creature
{
private:
    int fireMagic, waterMagic, earthMagic, airMagic;
public:
    magicCharacter(const string& _Name, int _healthPoints, int _strenght, int _agility, int _endurance, int _fireMagic, int _waterMagic, int _earthMagic, int _airMagic) :
        Creature(_Name, _healthPoints, _strenght, _agility, _endurance), fireMagic(_fireMagic), waterMagic(_waterMagic), earthMagic (_earthMagic), airMagic(_airMagic) {}
    magicCharacter(const magicCharacter& obj) : Creature(obj), fireMagic(obj.fireMagic), waterMagic(obj.waterMagic), earthMagic(obj.earthMagic), airMagic(obj.airMagic) {}
    magicCharacter(const string& _Name, int _healthPoints, int _strenght, int _agility, int _endurance, int _fireMagic, int _waterMagic, int _earthMagic, int _airMagic, int _dX, int _dY) :
        Creature(_Name, _healthPoints, _strenght, _agility, _endurance, _dX, _dY), fireMagic(_fireMagic), waterMagic(_waterMagic), earthMagic(_earthMagic), airMagic(_airMagic) {}
    ~magicCharacter() {}
    void move(int X, int Y) override {
        Creature::_move(X, Y);
        cout << "______________________________________________________________" << endl;
       cout << "\nМагический персонаж переместился в: (" << getX() << ";" << getY() << ")" << endl;
    }
    void draw() override
    {
        cout << "Местоположение магического персонажа: (" << getX() << ";" << getY() << ")" << endl;
    }
protected:
    void _print() const override
    {
        Creature::_print();
        cout << "Магия огня: " << fireMagic << "\nМагия воды: " << waterMagic << "\nМагия земли: " << earthMagic << "\nМагия воздуха: " << airMagic << endl;
    }
};

class magicItem : public ComputerGameObject
{
private:
    int level;
    int dX;
    int dY;
public:
    magicItem(const string& _level) : ComputerGameObject(_level), dX(0), dY(0), level(0) {}
    magicItem(const string& _Name, int _level) :ComputerGameObject(_Name), level(_level), dX(0), dY(0) {}
    magicItem(const string& _Name, int _level, int _dX, int _dY) :
        ComputerGameObject(_Name), level(_level), dX(_dX), dY(_dY) {}
    magicItem(const magicItem& obj) :ComputerGameObject(obj), level(obj.level), dX(obj.dX), dY(obj.dY) {}
    ~magicItem() {}
    void draw() override
    {
        cout << "______________________________________________________________" << endl;
        cout << "\nМестоположение магического предмета: (" << dX << ";" << dY << ")\n";
    }
protected:
    void _print()const override
    {
        ComputerGameObject::_print();
        cout << "Уровень: " << level << "\nX: " << dX << "\nY: " << dY << endl << endl;
        cout << "______________________________________________________________" << endl;
    }
};

int main()
{
    setlocale(0, "rus");
    mythicalAnimal animal("Dark Willow", 1760, 20, 18, 18, 1);
    animal.move(1222, 1354);
    animal.draw();
    animal.print();

    human human("Mirana", 1820, 18, 18, 18, 30, 1);
    human.move(1000, 1300);
    human.draw();
    human.print();

    magicCharacter magicCharacter("Invoker", 1940, 18, 14, 15, 3, 2, 5 , 4);
    magicCharacter.move(1000, 50);
    magicCharacter.draw();
    magicCharacter.print();

    magicItem magicItem("WRAITH BAND", 2, 1, 1);
    magicItem.draw();
    magicItem.print();
    return 0;
}

