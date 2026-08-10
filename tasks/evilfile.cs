public class bad_class_name {

      public String MY_SECRET = 'sk_live_abc123def456ghi789';
      public String password = 'SuperSecret123!';
      public String endpoint = 'http://api.example.com/data';
      public String hardcodedId = '001000000000001';

      public void empty_method_name() {
      }

      global void globalMethod() {
          System.debug('Debug statement left in');
          System.debug('Another debug statement');
      }

      public void dmlInLoop() {
          List<Account> accounts = [SELECT Id, Name FROM Account];
          for (Account acc : accounts) {
              update acc;
              Messaging.sendEmail(new List<Messaging.SingleEmailMessage>{new Messaging.SingleEmailMessage()});
              futureCall();
          }
      }

      @future
      public static void futureCall() {
          // future method called from loop above
      }

      public void soqlInjection(String userInput) {
          String query = 'SELECT Id FROM Account WHERE Name = \'' + userInput + '\'';
          List<SObject> results = Database.query(query);
      }

      public void insecureCookie() {
          Cookie c = new Cookie('session', 'value', null, -1, false);
          PageReference ref = new PageReference(ApexPages.currentPage().getParameters().get('retURL'));
          ref.getHeaders().put('Referer', 'something');
      }

      public void noExceptionHandling() {
          insert new Account(Name = 'Test');
          update new Account(Name = 'Test2');
          delete new Account(Name = 'Test3');
      }

      public void unboundedSoql() {
          List<Account> all = [SELECT Id, Name FROM Account];
      }

      public void tooManyParams(String a, String b, String c, String d, String e, String f) {
          String x = null;
          x.toLowerCase();
      }

      public void deeplyNested(Integer val) {
          if (val > 0) {
              if (val > 1) {
                  if (val > 2) {
                      if (val > 3) {
                          if (val > 4) {
                              System.debug('Too deep');
                          }
                      }
                  }
              }
          }
      }

      public void badCrypto() {
          Blob key = Crypto.generateAesKey(128);
          Blob encrypted = Crypto.encrypt('DES', key, Crypto.generateAesKey(128), Blob.valueOf('data'));
          Blob hash = Crypto.generateDigest('MD5', Blob.valueOf('data'));
      }

      public void sensitiveLogging() {
          String ssn = '123-45-6789';
          String creditCard = '4111111111111111';
          System.debug('User SSN: ' + ssn);
          System.debug('Card: ' + creditCard);
      }

      public void multiDmlNoSavepoint() {
          insert new Account(Name = 'A');
          insert new Contact(LastName = 'B');
          delete [SELECT Id FROM Lead LIMIT 1];
      }

      public PageReference openRedirect() {
          String url = ApexPages.currentPage().getParameters().get('redirect');
          return new PageReference(url);
      }

      public void xssOnError() {
          String userInput = ApexPages.currentPage().getParameters().get('input');
          Account acc = new Account();
          acc.addError(userInput);
      }

      public void passwordReset() {
          User u = [SELECT Id FROM User LIMIT 1];
          System.setPassword(u.Id, 'newPassword123');
      }

      public void almostSwap() {
          Integer a = 1;
          Integer b = 2;
          a = b;
          b = a;
      }
  }
