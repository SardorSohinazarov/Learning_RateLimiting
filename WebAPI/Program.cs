using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(x =>
{
    x.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    x.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(60);
        options.PermitLimit = 60;
        options.QueueLimit = 20;
    });

    x.AddSlidingWindowLimiter("sliding", options =>
    {
        options.Window = TimeSpan.FromSeconds(60);
        options.SegmentsPerWindow = 6;
        options.PermitLimit = 60;
        options.QueueLimit = 10;
    });

    x.AddTokenBucketLimiter("bucket", options =>
    {
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(60);
        options.TokenLimit = 60;
        options.TokensPerPeriod = 30;
        options.AutoReplenishment = true;
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter();
app.UseAuthorization();
app.MapControllers();

app.Run();