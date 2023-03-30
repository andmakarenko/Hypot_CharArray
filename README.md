# Hypot_CharArray
Algorithm that draws a line between any given two points in a 2-dimensional char array implemented by the "Strategy" design pattern.

With any two point with known coordinates given, this program draws the shortest way from one point to another. This was managed by subtracting X and Y coords of the first point from the second one, which allows to calculate delta Y and delta X and then while changing the Y value we get the required X change from the (dx/dy)
expression.
