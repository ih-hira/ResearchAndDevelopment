from PIL import Image # type: ignore
import face_recognition # type: ignore
image = face_recognition.load_image_file("E:/Kali_Backup/leaked-data/doc/182.71.247.90/CSE-IV-Year/1901430100001-.JPG")
face_locations = face_recognition.face_locations(image)
for face_location in face_locations:
    top, right, bottom, left = face_location
    print("A face is located at pixel location Top: {}, Left: {}, Bottom: {}, Right: {}".format(top, left, bottom, right))

    # You can access the actual face itself like this:
    face_image = image[top:bottom, left:right]
    pil_image = Image.fromarray(face_image)
    pil_image.show()