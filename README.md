# Inventory-system

[Inventory system gif](https://user-images.githubusercontent.com/105884435/184649534-75b88c1f-189b-4600-b9d1-21c3a03a36ca.gif)

# Player controls:
- awsd or key arrows for player movement
- escape button quits game.
- i open/close inventory.
- left shift open/close stats.
- left ctrl open/close equipment screen.
- left mouse button attacks if you have a weapon.
-top left slot in the loadout screen can equip(sword,axe,katana)
-top right slot in the loadout screen can equip(spear)
-bottom left slot in the loadout screen can equip(the 4 necklaces)
-bottom right slot in the loadout screen can equip(pumpkin, soup)
-inventory system is a drag and drop system
-left click on a item to use it

# Inventory scripts

//inventory.cs
-open/close inventory screen
-add items to inventory slots
-remove items from the inventory

//inventorySlot.cs
-checks if any item is in the slot
-handles the onDrop function
-has a game object as a child which contains the dragItem & dropItem scripts

//dragItem.cs
-handles the pointerDrag functions

//dropItem.cs
-has function for dropping an item
-has function for using an item
-has 2 buttons(use, remove)


# loadout scripts

//loadout.cs
-open/close inventory screen

//loadOutSlot.cs
-checks if any item is in the slot
-handles the onDrop function
-has a gameobject as a child which contains the dragItem & dropItem scripts
-only specific items can be added in certain loadout slots

//dragItem.cs
-handles the pointerDrag functions

//dropItem.cs
-has function for dropping an item
-has function for using an item
-has 2 buttons(use, remove)

# Player scripts

//playerMove.cs
-handles player movement

//playerHunger.cs
-reduces player health every 5 seconds

//interact.cs
-checks in which layer the picked up item is
-calls the inventory function to add an item

//healthBar.cs
-has 2 functions to add/remove health

# Other scripts

//floorDrop.cs
-checks if an item has been dragged and dropped outside of the inventory/loadout screen

//whatSlot.cs
-checks what type of a slot the parent object is

//stats.cs
-handles the stats menu
-displays player 

//item.cs
-scriptable object script
-can set if a item nam, description and attributes
