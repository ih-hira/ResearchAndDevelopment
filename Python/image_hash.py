from PIL import Image # type: ignore
import imagehash # type: ignore
hash = imagehash.average_hash(Image.open('./CSE-IV-Year/1901430100136.JPG'))
print(hash)