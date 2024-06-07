initial_amount = 160000
additional_monthly = 7000
time_in_years = 10
#%%
for i in range(time_in_years * 12):
    initial_amount += initial_amount * 0.07 / 12
    initial_amount += additional_monthly
    #print("In month", i, "your investment was", initial_amount)    
#%%
print("Total in", time_in_years, "years is:", "${0:.0f}".format(initial_amount))
monthly = initial_amount * 0.04 / 12
print("Monthly:", "${0:.0f}".format(monthly))
