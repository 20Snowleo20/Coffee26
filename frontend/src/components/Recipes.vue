<script setup>
import americano_recipe from '../assets/image/americano_recipe.jpg'
import latte_recipe from '../assets/image/latte_recipe.jpg'
import cappuchino_recipe from '../assets/image/cappuchino_recipe.jpg'
import mocco_recipe from '../assets/image/mocco_recipe.jpg'
import espresso_recipe from '../assets/image/espresso_recipe.jpg'
import raf_recipe from '../assets/image/raf_recipe.jpg'
import macchiato_recipe from '../assets/image/macchiato_recipe.jpg'
</script>


<template>
    <main class="text-slate-700 bg-cover bg-center bg-no-repeat">
        <section class="bg-blue-100 p-4">
            <h1 class="text-center py-2 md:text-2xl text-sm font-semibold">Рецепты</h1>
            <h2 class="text-center py-2 md:text-xl text-sm font-semibold">
                Парочка неплохих рецептов для вас
            </h2>
        </section>
    </main>

    <h2 class="text-center md:text-xl text-sm font-semibold py-2 md:py-4" id = "americano">Американо</h2>
    <section class="bg-slate-100 py-6 flex flex-col md:flex-row items-start gap-6">
        <div class="w-full md:w-1/3 flex justify-center">
            <img :src="americano_recipe" alt="Фото американо" class="w-full max-w-xs h-auto" />
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для рожковой кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе свежей обжарки 18&nbsp;г</li>
                <li>&bull; Вода для эспрессо 30&nbsp;мл</li>
                <li>&bull; Горячая вода 120-150&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Приготовить двойной эспрессо объемом 30&nbsp;мл за&nbsp;25-30&nbsp;секунд. В&nbsp;чашку заранее налить горячую воду температурой около 85&deg;C. Аккуратно добавить эспрессо поверх воды. Напиток сохраняет насыщенный кофейный вкус и&nbsp;мягкую горечь.</p>
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для гейзерной кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Молотый кофе 15-18&nbsp;г</li>
                <li>&bull; Вода 150&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Заполнить нижнюю часть кофеварки горячей водой до&nbsp;клапана. Насыпать кофе в&nbsp;фильтр без утрамбовки. Приготовить напиток на&nbsp;слабом огне. Полученный концентрированный кофе перелить в&nbsp;чашку и&nbsp;при необходимости добавить 80-100&nbsp;мл горячей воды.</p>
        </div>
    </section>

    <h2 class="text-center md:text-xl text-sm font-semibold py-2 md:py-4" id = "latte">Латте</h2>
    <section class="bg-slate-100 py-6 flex flex-col md:flex-row items-start gap-6">
        <div class="w-full md:w-1/3 flex justify-center">
            <img :src="latte_recipe" alt="Фото латте" class="w-full max-w-xs h-auto" />
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для рожковой кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Эспрессо 30&nbsp;мл</li>
                <li>&bull; Молоко 200&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Приготовить двойной эспрессо. Молоко охладить до&nbsp;4-6&deg;C и&nbsp;взбить паром до&nbsp;температуры 60-65&deg;C. Влить молоко в&nbsp;стакан, создавая однородную текстуру без крупных пузырей. Добавить эспрессо. Итоговый объем напитка около 230&nbsp;мл.</p>
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для гейзерной кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе из&nbsp;гейзерной кофеварки 60&nbsp;мл</li>
                <li>&bull; Молоко 180-200&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Сварить крепкий кофе. Молоко нагреть до&nbsp;60&deg;C и&nbsp;взбить капучинатором. Наполнить стакан молоком, затем влить кофе тонкой струйкой. При желании украсить латте-артом.</p>
        </div>
    </section>

    <h2 class="text-center md:text-xl text-sm font-semibold py-2 md:py-4" id = "cappuchino">Капучино</h2>
    <section class="bg-slate-100 py-6 flex flex-col md:flex-row items-start gap-6">
        <div class="w-full md:w-1/3 flex justify-center">
            <img :src="cappuchino_recipe" alt="Фото капучино" class="w-full max-w-xs h-auto" />
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для рожковой кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Эспрессо 30&nbsp;мл</li>
                <li>&bull; Молоко 120&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Приготовить двойной эспрессо. Взбить молоко до&nbsp;получения бархатистой микропены. Влить молоко в&nbsp;чашку с&nbsp;эспрессо, сохраняя баланс кофе, молока и&nbsp;пены. Объем готового напитка около 150-180&nbsp;мл.</p>
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для гейзерной кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе из&nbsp;гейзера 60&nbsp;мл</li>
                <li>&bull; Молоко 90-120&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Сварить насыщенный кофе. Подогреть молоко и&nbsp;взбить до&nbsp;плотной кремовой текстуры. Соединить кофе с&nbsp;молоком и&nbsp;завершить напиток слоем молочной пены толщиной около 1&nbsp;см.</p>
        </div>
    </section>

    <h2 class="text-center md:text-xl text-sm font-semibold py-2 md:py-4" id = "mocco">Мокко</h2>
    <section class="bg-slate-100 py-6 flex flex-col md:flex-row items-start gap-6">
        <div class="w-full md:w-1/3 flex justify-center">
            <img :src="mocco_recipe" alt="Фото мокко" class="w-full max-w-xs h-auto" />
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для рожковой кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Эспрессо 30&nbsp;мл</li>
                <li>&bull; Шоколадный соус 20&nbsp;г</li>
                <li>&bull; Молоко 150&nbsp;мл</li>
                <li>&bull; Взбитые сливки по&nbsp;желанию</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>На&nbsp;дно стакана добавить шоколадный соус. Влить свежеприготовленный эспрессо и&nbsp;тщательно размешать. Добавить горячее вспененное молоко. По&nbsp;желанию украсить взбитыми сливками и&nbsp;шоколадной стружкой.</p>
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для гейзерной кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе из&nbsp;гейзера 60&nbsp;мл</li>
                <li>&bull; Шоколадный соус 20&nbsp;г</li>
                <li>&bull; Молоко 130-150&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Растворить шоколадный соус в&nbsp;горячем кофе. Подогреть молоко до&nbsp;60-65&deg;C и&nbsp;слегка вспенить. Соединить ингредиенты в&nbsp;стакане и&nbsp;перемешать до&nbsp;однородной текстуры.</p>
        </div>
    </section>

    <h2 class="text-center md:text-xl text-sm font-semibold py-2 md:py-4 " id = "espresso">Эспрессо</h2>
    <section class="bg-slate-100 py-6 flex flex-col md:flex-row items-start gap-6">
        <div class="w-full md:w-1/3 flex justify-center">
            <img :src="espresso_recipe" alt="Фото эспрессо" class="w-full max-w-xs h-auto" />
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для рожковой кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе 18&nbsp;г</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Использовать свежемолотый кофе среднего или тонкого помола. Равномерно распределить кофе в&nbsp;корзине и&nbsp;утрамбовать темпером. Экстрагировать 30-40&nbsp;мл напитка за&nbsp;25-30&nbsp;секунд. Готовый эспрессо должен иметь плотную золотистую крема.</p>
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для гейзерной кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе 15-18&nbsp;г</li>
                <li>&bull; Вода 90&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Заполнить резервуар горячей водой до&nbsp;предохранительного клапана. Засыпать кофе в&nbsp;фильтр без прессования. Готовить на&nbsp;слабом огне до&nbsp;завершения экстракции. Подавать сразу после приготовления.</p>
        </div>
    </section>

    <h2 class="text-center md:text-xl text-sm font-semibold py-2 md:py-4" id = "raf">Раф</h2>
    <section class="bg-slate-100 py-6 flex flex-col md:flex-row items-start gap-6">
        <div class="w-full md:w-1/3 flex justify-center">
            <img :src="raf_recipe" alt="Фото раф-кофе" class="w-full max-w-xs h-auto" />
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для рожковой кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Эспрессо 30&nbsp;мл</li>
                <li>&bull; Сливки&nbsp;10% 150&nbsp;мл</li>
                <li>&bull; Ванильный сироп 15&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Соединить эспрессо, сливки и&nbsp;сироп в&nbsp;питчере. Прогреть и&nbsp;одновременно взбить паром до&nbsp;температуры 60-65&deg;C. Напиток должен получиться однородным и&nbsp;воздушным без разделения на&nbsp;слои.</p>
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для гейзерной кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе из&nbsp;гейзера 60&nbsp;мл</li>
                <li>&bull; Сливки&nbsp;10% 130-150&nbsp;мл</li>
                <li>&bull; Ванильный сироп 15&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Смешать горячий кофе со&nbsp;сливками и&nbsp;сиропом. Взбить капучинатором до&nbsp;появления легкой кремовой пены. Подавать в&nbsp;прогретом стеклянном стакане.</p>
        </div>
    </section>

    <h2 class="text-center md:text-xl text-sm font-semibold py-2 md:py-4" id = "macchiato">Макиато</h2>
    <section class="bg-slate-100 py-6 flex flex-col md:flex-row items-start gap-6">
        <div class="w-full md:w-1/3 flex justify-center">
            <img :src="macchiato_recipe" alt="Фото макиато" class="w-full max-w-xs h-auto" />
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для рожковой кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Эспрессо 30&nbsp;мл</li>
                <li>&bull; Молочная пена 15-20&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Приготовить свежий эспрессо. Взбить небольшое количество молока до&nbsp;плотной текстуры. Выложить сверху ложку молочной пены, сохранив выраженный кофейный вкус напитка.</p>
        </div>
        <div class="w-full md:w-1/3 flex flex-col gap-3 text-sm leading-relaxed px-4">
            <h3 class="font-semibold text-base">Для гейзерной кофеварки</h3>
            <h4 class="font-semibold">Ингредиенты</h4>
            <ul class="space-y-1">
                <li>&bull; Кофе из&nbsp;гейзера 60&nbsp;мл</li>
                <li>&bull; Молочная пена 15-20&nbsp;мл</li>
            </ul>
            <h4 class="font-semibold pt-1">Приготовление</h4>
            <p>Сварить крепкий кофе в&nbsp;гейзерной кофеварке. Подготовить плотную молочную пену. Добавить пену поверх кофе непосредственно перед подачей. Это позволяет сохранить характерную контрастность вкуса.</p>
        </div>
    </section>
</template>