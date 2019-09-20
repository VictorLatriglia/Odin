class ObjectDetected:
    startX = 0
    endX = 0
    startY = 0
    endY = 0
    label = ""
    def __init__(self, startX,endX,startY,endY,label):
        self.startX = startX
        self.endX = endX
        self.startY = startY
        self.endY = endY
        self.label = label