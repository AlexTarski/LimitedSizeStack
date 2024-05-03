# LimitedSizeStack

This project is a simple task manager: you can add or remove tasks from the list and
undo your actions if it would be necessary.

ListModel.undoLimit - count of possible undo actions.
CanUndo() - check if it`s possible to undo the action.

The "LimitedSizeStack" class implements a stack of limited size:
it works almost like a usual stack, but when it reaches its maximum capacity,
the deepest (first) element will be removed before adding a new one.

Hence, stack always stay of limited size.

LimitedSizeStack keeps the history of operations in it.