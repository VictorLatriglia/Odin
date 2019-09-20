import json
class ReportService:
   
    def Report(self,data):
        for info in data:
            jsonData = json.dumps(info.__dict__)
            print("json "+jsonData)