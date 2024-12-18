using Practice.BuildComplicatedFlow.Interface;
using Practice.BuildComplicatedFlow.Services;
using Practice.BuildComplicatedFlow.Steps;
using Practice.BuildComplicatedFlow.Steps.Clean;
using Practice.BuildComplicatedFlow.Steps.CopyMainPart0;
using Practice.BuildComplicatedFlow.Steps.CopyMainPart1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

//Main
builder.Services.AddScoped<IMainService, MainService>();
builder.Services.AddScoped<ICopyProcess, CopyProcess>();

builder.Services.AddMainFlowCopy();

//Step0
builder.Services.AddCopyMainPart0();
builder.Services.AddCopyMainPart1();
builder.Services.AddClean();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
