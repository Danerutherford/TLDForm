@Code
    ViewData("Title") = "Home Page"
End Code

<html>
<body>
    <h2>Order Form</h2>
    <form>
        <div id="HomePage">
            <p>Account Number: <input id="AccountNbr" type="text" name="AccountNbr"></p>
            <p>Account Name 1: <input id="AccountName1" type="text" name="AccountName1"></p>
            <p>Account Name 2: <input id="AccountName2" type="text" name="AccountName2"></p>
            <p>First Name: <input id="Fname" type="text" name="Fname"></p>
            <p>Last Name: <input id="Lname" type="text" name="Lname"></p>
            <p>ID Number: <input id="IDNbr" type="text" name="IDNbr"></p>
            <p>Holder Type: <input id="HType" type="text" name="HType" value="LA" maxlength="2"></p>
            <p>Neutron: <input id="NT" type="text" name="NT" value="NT" maxlength="2"></p>
            <p>Barcode: <input id="BarCode" type="text" name="BarCode" maxlength="12"></p>
            <p>Wear Location: <input id="WLocation" type="text" name="WLocation" value="WB" maxlength="2"></p>
            <p>Use Period Description: <input id="UPD" type="text" name="UPD" maxlength="11"></p>
            <p>Series Name: <input id="SName" type="text" name="SName" maxlength="17"></p>
            <p>Customer Key: <input id="CKey" type="text" name="CKey" maxlength="25"></p>

            <p>
                Clip Type: <select>
                    <option value="SL"> SL- Slotted Clip</option>
                    <option value="AL">AL- Alligator Clip</option>
                </select>
            </p>
            <p>
                Series Color: <select>
                    <option value="BL"> BL- Blue </option>
                    <option value="GR">GR - Green</option>
                    <option value="LB">LB - Light Blue</option>
                    <option value="NO">NO - None</option>
                    <option value="OR">OR - Orange</option>
                    <option value="PP">PP - Purple</option>
                    <option value="RD">RD - Red</option>
                </select>
            </p>
            <p>
                Frequency Color: <select>
                    <option value="BL"> BL- Blue </option>
                    <option value="GR">GR - Green</option>
                    <option value="LB">LB - Light Blue</option>
                    <option value="NO">NO - None</option>
                    <option value="OR">OR - Orange</option>
                    <option value="PP">PP - Purple</option>
                    <option value="RD">RD - Red</option>
                </select>
            </p>
            <p>
                Badge Use: <select>
                    <option value="PA"> PA- Participant </option>
                    <option value="AR">AR - Area Monitor</option>
                    <option value="CO">CO - Control</option>
                </select>
            </p>

        </div>
        <div id="buttonHolder">
            <input type="submit" id="btn_s" value="Submit" title="Submit">

        </div>



    </form>

</body>

</html>
